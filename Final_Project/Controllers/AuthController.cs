using Asp.Versioning;
using ByWay.ServicesLayer.DTO;
using ByWay.ServicesLayer.Service.Contact_Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] StudentRegisterDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { message = "Invalid registration data." });

        // Ensure valid username
        if (string.IsNullOrWhiteSpace(model.UserName))
            model.UserName = model.Email.Split('@')[0];

        model.UserName = new string(model.UserName.Where(char.IsLetterOrDigit).ToArray());

        if (string.IsNullOrWhiteSpace(model.UserName))
            model.UserName = "User" + Guid.NewGuid().ToString("N").Substring(0, 6);

        var result = await _authService.RegisterAsync(model, role: "Student");

        if (!result.IsAuthenticated)
            return BadRequest(new { message = result.Message });

        return Ok(new
        {
            message = "Registration successful.",
            token = result.Token,
            user = result
        });
    }

    [HttpPost("admin-login")]
    public async Task<IActionResult> AdminLogin([FromBody] StudentLoginDto model)
    {
        var result = await _authService.AdminLoginAsync(model);
        if (!result.IsAuthenticated)
            return Unauthorized(new { message = result.Message });

        return Ok(new { message = "Admin login successful.", token = result.Token, user = result });
    }

    [HttpPost("user-login")]
    public async Task<IActionResult> UserLogin([FromBody] StudentLoginDto model)
    {
        var result = await _authService.UserLoginAsync(model, role: "Student");
        if (!result.IsAuthenticated)
            return Unauthorized(new { message = result.Message });

        return Ok(new { message = "Login successful.", token = result.Token, user = result });
    }

    [HttpGet("students")]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _authService.GetAllStudentsAsync();
        return Ok(students);
    }
}
