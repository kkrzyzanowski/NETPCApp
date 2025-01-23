using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETPCApp.Application.DTOs;
using NETPCApp.Application.Interfaces;

namespace NETPCApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Logowanie użytkownika
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await _authService.LoginAsync(loginDto.Email, loginDto.Password);
            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { Message = "Invalid email or password" });

            return Ok(new { Token = token });
        }

    }

}
