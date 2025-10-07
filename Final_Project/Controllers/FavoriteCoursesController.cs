using Asp.Versioning;
using ByWay.DomainLayer.Model;
using ByWay.ServicesLayer.Service.Contact_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ByWay_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    public class FavoriteCoursesController : ControllerBase
    {
        private readonly IFavoriteCourseService _favoriteService;
        private readonly UserManager<Student> _userManager;

        public FavoriteCoursesController(IFavoriteCourseService favoriteService, UserManager<Student> userManager)
        {
            _favoriteService = favoriteService;
            _userManager = userManager;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(string studentId, int courseId)
        {
            // Check if the student exists
            var student = await _userManager.FindByIdAsync(studentId);
            if (student == null)
                return BadRequest("Student must be LogIn or registered before adding favorites.");

            var result = await _favoriteService.AddFavoriteAsync(studentId, courseId);
            if (result == null)
                return BadRequest("Course already in favorites");

            return Ok(result);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> Remove(string studentId, int courseId)
        {
            var removed = await _favoriteService.RemoveFavoriteAsync(studentId, courseId);
            if (!removed) return NotFound("Course not found in favorites");
            return Ok("Removed successfully");
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetFavorites(string studentId)
        {
            var favorites = await _favoriteService.GetUserFavoritesAsync(studentId);
            return Ok(favorites);
        }
    }
}
 