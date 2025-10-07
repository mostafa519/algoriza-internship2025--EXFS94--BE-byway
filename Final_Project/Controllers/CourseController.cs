using Asp.Versioning;
using ByWay.ServicesLayer.DTO;
using ByWay.ServicesLayer.Service.Contact_Interface;
using ByWay.ServicesLayer.Service.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ByWay_API.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _courseService;

        public CourseController(ICourse courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("Courses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course == null)
                return NotFound();

            return Ok(course);
        }
        [HttpGet("Name/{name}")]
        public async Task<IActionResult> GetCourseByName(string name)
        {
            var course = await _courseService.GetCourseByName(name);
            if (course == null)
                return NotFound();

            return Ok(course);
        }
        [HttpGet("Rate/{rate}")]
        public async Task<IActionResult> GetCourseByRate(double rate)
        {
            var courses = await _courseService.GetCoursesByRate(rate);
            if (courses == null || !courses.Any())
                return NotFound("No courses found with this Rate.");

            return Ok(courses);
        }
        [HttpGet("price/{price}")]
        public async Task<IActionResult> GetCoursesByPrice(decimal price)
        {
            var courses = await _courseService.GetCoursesByPrice(price);
            if (courses == null || !courses.Any())
                return NotFound("No courses found with this price.");

            return Ok(courses);
        }
        [HttpGet("Category/{category}")]
        public async Task<IActionResult> GetCoursesByCategory(string category)
        {
            var courses = await _courseService.GetCoursesByCategory(category);
            if (courses == null || !courses.Any())
                return NotFound("No courses found with this Category.");

            return Ok(courses);
        }
        [HttpGet("Duration/{duration}")]
        public async Task<IActionResult> GetCoursesByDuration(int duration)
        {
            var courses = await _courseService.GetCoursesByDuration(duration);
            if (courses == null || !courses.Any())
                return NotFound("No courses found with this Duration.");

            return Ok(courses);
        }
        [HttpGet("Level/{level}")]
        public async Task<IActionResult> GetCoursesByLevel(string level)
        {
            var courses = await _courseService.GetCoursesByLevel(level);
            if (courses == null || !courses.Any())
                return NotFound("No courses found with this Duration.");

            return Ok(courses);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddCourses([FromForm]CreateCourseDto course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCourse = await _courseService.AddCourse(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = createdCourse.Id }, createdCourse);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] UpdateCourseDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            var updatedCourse = await _courseService.UpdateCourse(dto);
            if (updatedCourse == null)
                return NotFound();

            return Ok(updatedCourse);
        }

        // DELETE: api/Course/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var deleted = await _courseService.DeleteCourse(id);

            if (!deleted)
            {
                // Could not delete because course either not found or has students/instructors
                return BadRequest("Cannot delete course. Either not found or assigned to students or instructors.");
            }

            return Ok(new { message = "Course deleted successfully." });
        }
        [HttpGet("Filtered")]
        public async Task<IActionResult> GetAllCoursesFiltered(
      [FromQuery] int page = 1,
      [FromQuery] int pageSize = 9,
      [FromQuery] string? name = null,
      [FromQuery] string? category = null,
      [FromQuery] double? rate = null,
      [FromQuery] decimal? price = null,
      [FromQuery] int? duration = null,
      [FromQuery] string? level = null)
        {
            var courses = await _courseService.GetAllCoursesFiltered(
                page,
                pageSize,
                c =>
                    (string.IsNullOrEmpty(name) || c.Name.Contains(name)) &&
                    (string.IsNullOrEmpty(category) || c.CategoryName.Contains(category)) &&
                    (!rate.HasValue || c.Rate == rate.Value) &&
                    (!price.HasValue || c.Price == price.Value) &&
                    (!duration.HasValue || c.DurationInHours == duration.Value) &&
                    (string.IsNullOrEmpty(level) || c.Level.Contains(level))
            );

            if (!courses.Any())
                return NotFound("No courses found with the specified filters.");

            return Ok("Filtered Courses");
        }


    }
}
