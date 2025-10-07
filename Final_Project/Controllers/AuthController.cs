using Asp.Versioning;
using ByWay.DomainLayer.ModelAuth;
using ByWay.ServicesLayer.DTO;
using ByWay.ServicesLayer.Service.Contact_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ByWay_API.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // ---------------- Register User ----------------
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(
            [FromBody] StudentRegisterDto model,
            [FromQuery] string role = "Student")
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid registration data." });

            var result = await _authService.RegisterAsync(model, role);

            if (!result.IsAuthenticated)
                return BadRequest(new { message = result.Message });

            return Ok(new
            {
                message = "Registration successful.",
                token = result.Token,
                user = result
            });
        }

        // ---------------- Admin Login ----------------
        [HttpPost("admin-login")]
        public async Task<IActionResult> AdminLogin([FromBody] StudentLoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid login data." });

            var result = await _authService.AdminLoginAsync(model);

            if (!result.IsAuthenticated)
                return Unauthorized(new { message = result.Message });

            return Ok(new
            {
                message = "Admin login successful.",
                token = result.Token,
                user = result
            });
        }

        // ---------------- Student Login ----------------
        [HttpPost("user-login")]
        public async Task<IActionResult> UserLogin(
            [FromBody] StudentLoginDto model,
            [FromQuery] string role = "Student")
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid login data." });

            var result = await _authService.UserLoginAsync(model, role);

            if (!result.IsAuthenticated)
                return Unauthorized(new { message = result.Message });

            return Ok(new
            {
                message = "Login successful.",
                token = result.Token,
                user = result
            });
        }

        // ---------------- Get All Students ----------------
        [HttpGet("students")] 
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _authService.GetAllStudentsAsync();
            return Ok(students);
        }
    }
}
