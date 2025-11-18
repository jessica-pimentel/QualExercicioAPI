using Microsoft.AspNetCore.Mvc;
using QualExercicioAPI.Models.DTOs;
using QualExercicioAPI.Services.Interfaces;
using QualExercicioAPI.Settings;

namespace QualExercicioAPI.Controllers.v1.features.Auth
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;

        public AuthController(IAuthService authService, IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _authService.Validate(dto.Email, dto.Password);

            if (user == null)
                return Unauthorized("Email ou senha inválidos.");

            // "Admin" ou "Student"
            var token = _jwtService.GenerateToken(user.Email, user.Id, user.Role.ToString());

            return Ok(new { token });
        }
    }
}
