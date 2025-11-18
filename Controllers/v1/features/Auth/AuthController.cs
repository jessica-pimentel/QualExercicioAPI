using Microsoft.AspNetCore.Mvc;

namespace QualExercicioAPI.Controllers.v1.features.Auth
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            return Ok(new { token = "fake-jwt-token" });
        }
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
