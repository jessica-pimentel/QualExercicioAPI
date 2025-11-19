using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QualExercicioAPI.Models.DTOs.Auth;
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

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateUserDto dto)
        {
            var result = _authService.ValidateCreate(dto.Name, dto.Email, dto.Password, dto.ConfirmPassword);

            if (result == null)
                return BadRequest("Erro ao criar usuário.");

            var token = _jwtService.GenerateToken(result.Email, result.Id, result.Role.ToString());

            return Ok(new { token });
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

        [Authorize]
        [HttpPut("update-password")]
        public IActionResult UpdatePassword([FromBody] UpdatePasswordDto dto)
        {
            var userId = int.Parse(User.FindFirst("sub")!.Value);

            var result = _authService.UpdatePassword(userId, dto.OldPassword, dto.NewPassword, dto.ConfirmNewPassword);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}
