﻿using AdvertisingService.Customers.Contracts;
using Contracts;
using AdvertisingService.Customers.Entities;
using AdvertisingService.Customers.Services.Abstract;
using AdvertisingService.Customers.Services.Concrete;
using MassTransit;
using MassTransit.Internals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography.Xml;
using AutoMapper;

namespace AdvertisingService.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IAdminService _adminService;
        private readonly IPersonalService _personalService;
        private readonly IBusControl _busControl;

        public AccountController(IMapper mapper, UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenService jwtTokenService, IBusControl busControl)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenService = jwtTokenService;
            _busControl = busControl;
            _personalService = new PersonalService(mapper, userManager, roleManager, busControl);
            _adminService = new AdminService(userManager, roleManager);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto registerUser)
        {
            if (registerUser == null)
                return BadRequest();
            if (registerUser.Password != registerUser.ConfirmPassword)
                return BadRequest("Пароли не совпадают!");

            var user = _mapper.Map<Customer>(registerUser);
            Task<IdentityResult> createTask = _userManager.CreateAsync(user, registerUser.Password);
            await createTask;
            if (!createTask.IsCompletedSuccessfully)
            {
                var errors = createTask.Result.Errors.Select(x => x.Description);
                return BadRequest(string.Join(";", errors));
            }
            UserRegisterInfoDto userInfo = _mapper.Map<UserRegisterInfoDto>(user);
            await _busControl.Publish(userInfo);
            return StatusCode(201);
        }

        [HttpPost("authorize")]
        [AllowAnonymous]
        public async Task<IActionResult> Authorize([FromBody] UserLoginDto loginUser)
        {
            Customer? user = _userManager.Users.Single(u => u.UserName == loginUser.UserName);
            PasswordVerificationResult result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUser.Password);
            if (user == null || result == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Неверный логин/пароль");
            }
            else
            {
                var roles = _userManager.GetRolesAsync(user).Result;
                var token = await _jwtTokenService.GenerateToken(loginUser.UserName, roles);
                return Ok(token);
            }
        }

        [HttpPost("setrole")]
        [AllowAnonymous]
        public async Task<IActionResult> SetRoleToUser([FromBody] UserRoleDto userRole)
        {
            await _adminService.AddRoleAsync(userRole.role);
            Customer? user = _userManager.Users.Single(u => u.UserName == userRole.userName);
            if (user == null) return BadRequest($"Пользователя с логином {userRole.userName} не существует");
            Task setRole = _adminService.SetRoleAsync(user, userRole.role);
            await setRole;
            return setRole.IsCompletedSuccessfully ? Ok() : BadRequest($"Ошибка при установке пользователю {userRole.userName} роли {userRole.role}");
        }

        [HttpPost("updateinfo")]
        public async Task<IActionResult> UpdatePersonInfo([FromBody] UserInfoDto userInfo)
        {
            Customer? user = _userManager.Users.Single(u => u.UserName == userInfo.UserName);
            if (user == null) return BadRequest($"Пользователя с логином {userInfo.UserName} не существует");
            Task<Customer> updateTask = _personalService.SaveUpdateInfo(userInfo, user);
            await updateTask;
            return updateTask.IsCompletedSuccessfully ? Ok() : BadRequest($"Ошибка при обновлении данных пользователя {user.UserName}");
        }
    }
}
