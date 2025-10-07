using Asp.Versioning;
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
    public class InstructorController : ControllerBase
    {
        private readonly IInstructor _instructorService;

        public InstructorController(IInstructor instructorService)
        {
            _instructorService = instructorService;
        }

        // GET: api/Instructor
        [HttpGet]
        public async Task<IActionResult> GetAllInstructors()
        {
            var instructors = await _instructorService.GetAllInstructors();
            return Ok(instructors);
        }

        // GET: api/Instructor/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructorById(int id)
        {
            var instructor = await _instructorService.GetInstructorById(id);
            if (instructor == null)
                return NotFound();

            return Ok(instructor);
        }

        // GET: api/Instructor/by-name/{name}
        [HttpGet("byName/{name}")]
        public async Task<IActionResult> GetInstructorsByName(string name)
        {
            var instructors = await _instructorService.GetInstructorsByName(name);
            if (!instructors.Any())
                return NotFound("No instructors found with this name");

            return Ok(instructors);
        }

        // GET: api/Instructor/by-expertise/{expertise}
        [HttpGet("byExpertise/{expertise}")]
        public async Task<IActionResult> GetInstructorsByExpertise(string expertise)
        {
            var instructors = await _instructorService.GetInstructorsByExpertise(expertise);
            if (!instructors.Any())
                return NotFound("No instructors found with this expertise");

            return Ok(instructors);
        }

        // POST: api/Instructor
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddInstructor([FromForm] CreateInstructorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _instructorService.AddInstructor(dto);
            return CreatedAtAction(nameof(GetInstructorById), new { id = created.Id }, created);
        }

        // PUT: api/Instructor/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstructor(int id, [FromForm] UpdateInstructorDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            var updated = await _instructorService.UpdateInstructor(dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: api/Instructor/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            var deleted = await _instructorService.DeleteInstructor(id);

            if (!deleted)
            {
                // Could not delete because instructor either not found or assigned to courses
                return BadRequest("Cannot delete instructor. Either not found or assigned to one or more courses.");
            }

            return Ok(new { message = "Instructor deleted successfully." });
        }

        // GET: api/Instructor/Filtered
        [HttpGet("Filtered")]
        public async Task<IActionResult> GetAllInstructorsFiltered(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 9,
            [FromQuery] string? name = null,
            [FromQuery] string? JobTitle = null)
        {
            // Call service method with optional filters
            var instructors = await _instructorService.GetAllInstructorsFiltered(
                page,
                pageSize,
                i => (string.IsNullOrEmpty(name) || i.Name.Contains(name)) &&
                     (string.IsNullOrEmpty(JobTitle) || i.JobTitle.Contains(JobTitle))
            );

            if (!instructors.Any())
                return NotFound("No instructors found with the specified filters.");

            return Ok(instructors);
        }

    }
}
