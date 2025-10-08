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
        public async Task<IActionResult> Add( int courseId)
        {
            

            var result = await _favoriteService.AddFavoriteAsync( courseId);
            if (result == null)
                return BadRequest("Course already in favorites");

            return Ok(result);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> Remove(int courseId)
        {
            var removed = await _favoriteService.RemoveFavoriteAsync(courseId);
            if (!removed) return NotFound("Course not found in favorites");
            return Ok("Removed successfully");
        }
 
    }
}
 