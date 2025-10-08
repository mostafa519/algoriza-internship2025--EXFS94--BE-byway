using Asp.Versioning;
using ByWay.DomainLayer.Model;
using ByWay.RepositoryLayer;
using ByWay.ServicesLayer.Service.Contact_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        private readonly ApplicationDbContext _context;

        public FavoriteCoursesController(
            IFavoriteCourseService favoriteService,
            UserManager<Student> userManager,
            ApplicationDbContext context)
        {
            _favoriteService = favoriteService;
            _userManager = userManager;
            _context = context;
        }

        // 🔹 Add a course to favorites
        [Authorize(Roles = "Student")]
        [HttpPost("add")]
        public async Task<IActionResult> Add(int courseId)
        {
            if (courseId <= 0)
                return BadRequest("Invalid course ID");

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("Student not logged in");

            var course = await _context.Courses
                .FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null)
                return NotFound("Course not found");

            var exists = await _favoriteService.IsFavoriteAsync(courseId, user.Id);
            if (exists)
                return BadRequest("Course already in favorites");

            var favorite = await _favoriteService.AddFavoriteAsync(courseId, user.Id);
            if (favorite == null)
                return BadRequest("Unable to add course to favorites");

            return Ok(favorite); // includes student and course
        }

        // 🔹 Remove a course from favorites
        [Authorize(Roles = "Student")]
        [HttpDelete("remove")]
        public async Task<IActionResult> Remove(int courseId)
        {
            if (courseId <= 0)
                return BadRequest("Invalid course ID");

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("Student not logged in");

            var removed = await _favoriteService.RemoveFavoriteAsync(courseId, user.Id);
            if (!removed)
                return NotFound("Course not found in favorites");

            return Ok("Removed successfully");
        }

        // 🔹 Get all favorite courses for logged-in student
        [Authorize(Roles = "Student")]
        [HttpGet("all")]
        public async Task<IActionResult> GetFavorites()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("Student not logged in");

            var favorites = await _favoriteService.GetFavoritesAsync(user.Id);
            if (favorites == null || !favorites.Any())
                return NotFound("No favorite courses found");

            return Ok(favorites); // already includes Course and Student
        }
    }
}
