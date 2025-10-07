
using Asp.Versioning;
using ByWay.DomainLayer.Model;
using ByWay.ServicesLayer.DTO;
using ByWay.ServicesLayer.Service.Contact_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ByWay_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    public class StudentProfileController : ControllerBase
    {
        private readonly IStudentProfileService _profileService;

        public StudentProfileController(IStudentProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("me")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var profile = await _profileService.GetProfileAsync(userId);
            return Ok(profile);
        }

        [HttpPost("me")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> AddOrUpdateProfile([FromBody] StudentProfileDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var profile = new StudentProfile
            {
                StudentId = userId,
                Country = model.Country,
                State = model.State,
                CardName = model.CardName,
                CardNumber = model.CardNumber,
                ExpiryDate = model.ExpiryDate,
                CVC = model.CVC
            };

            var result = await _profileService.CreateOrUpdateProfileAsync(profile);
            return Ok(result);
        }
    }
}