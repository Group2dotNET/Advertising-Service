using AdvertisingService.Customers.DTO;
using AdvertisingService.Customers.Entities;
using AdvertisingService.Customers.Services;
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
        private readonly IJwtTokenService _jwtTokenService;

        public AccountController(UserManager<Customer> userManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("register")]
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
    }
}
