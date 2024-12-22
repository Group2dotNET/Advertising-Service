using AdvertisingService.Customers.DTO;
using AdvertisingService.Customers.Entities;
using AdvertisingService.Customers.Services.Abstract;
using AdvertisingService.Customers.Services.Concrete;
using AdvertisingService.Customers.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace AdvertisingService.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IAdminService _adminService;

        public AccountController(UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenService jwtTokenService/*, IAdminService adminService*/)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenService = jwtTokenService;
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

            var user = Mapper.Map(registerUser);
            IdentityResult result = await _userManager.CreateAsync(user, registerUser.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                return BadRequest(string.Join(";", errors));
            }
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
                return Unauthorized();
            }
            else
            {
                var roles = _userManager.GetRolesAsync(user).Result;
                var token = await _jwtTokenService.GenerateToken(loginUser.UserName, roles);
                return Ok(token);
            }
        }

        [HttpPost("setrole")]
        public async Task<IActionResult> SetRoleToUser([FromBody] UserRoleDto userRole)
        {
            Task addRole = _adminService.AddRoleAsync(userRole.role);
            Customer? user = _userManager.Users.Single(u => u.UserName == userRole.userName);
            if (user == null) return BadRequest($"Пользователя с логином {userRole.userName} не существует");
            await addRole;
            Task setRole = _adminService.SetRoleAsync(user, userRole.role);
            await setRole;
            return setRole.IsCompletedSuccessfully ? Ok() : BadRequest($"Ошибка при установке пользователю {userRole.userName} роли {userRole.role}");
        }
    }
}
