using Asp.Versioning;
using ByWay.DomainLayer.Model;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;

        public CategoryController(ICategory category)
        {
            _category = category;
        }

        // GET: api/category/categories
        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _category.GetAllCategoriesAsync();

            if (categories == null || !categories.Any())
                return NotFound("No categories found.");

            return Ok(categories);
        }

        // GET: api/category/courses
        //[HttpGet("courses")]
        //public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        //{
        //    var courses = await _category.GetAllCoursesAsync();

        //    if (courses == null || !courses.Any())
        //        return NotFound("No courses found.");

        //    return Ok(courses);
        //}
    }
}
