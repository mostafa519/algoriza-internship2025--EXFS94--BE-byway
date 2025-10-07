using AutoMapper;
using ByWay.DomainLayer.Model;
using ByWay.RepositoryLayer;
using ByWay.ServicesLayer.DTO;
using ByWay.ServicesLayer.Service.Contact_Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace ByWay.ServicesLayer.Service.Implementation
{
    public class InstructorServices : IInstructor
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _uploadPath;

        public InstructorServices(ApplicationDbContext context, IMapper mapper, string uploadPath)
        {
            _context = context;
            _mapper = mapper;
            _uploadPath = uploadPath;

            if (!Directory.Exists(_uploadPath))
                Directory.CreateDirectory(_uploadPath);
        }

        // ✅ Get All
        public async Task<IEnumerable<InstructorDto>> GetAllInstructors()
        {
            var instructors = await _context.Instructors.ToListAsync();

            return _mapper.Map<IEnumerable<InstructorDto>>(instructors);
        }

        // ✅ Get By Id
        public async Task<InstructorDto?> GetInstructorById(int id)
        {
            var instructor = await _context.Instructors.FirstOrDefaultAsync(i => i.Id == id);

            return instructor == null ? null : _mapper.Map<InstructorDto>(instructor);
        }

        // ✅ Get By Name
        public async Task<IEnumerable<InstructorDto>> GetInstructorsByName(string name)
        {
            var instructors = await _context.Instructors.ToListAsync();

            return _mapper.Map<IEnumerable<InstructorDto>>(instructors);
        }

        // ✅ Get By Expertise
        public async Task<IEnumerable<InstructorDto>> GetInstructorsByExpertise(string JobTitle)
        {
            var instructors = await _context.Instructors
                .Where(i => i.JobTitle.Contains(JobTitle))
                .ToListAsync();

            return _mapper.Map<IEnumerable<InstructorDto>>(instructors);
        }

        // ✅ Add Instructor (with Image upload)
        public async Task<InstructorDto> AddInstructor(CreateInstructorDto dto)
        {
            string? imageUrl = null;

            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}_{dto.ImageFile.FileName}";
                var filePath = Path.Combine(_uploadPath, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await dto.ImageFile.CopyToAsync(stream);

                imageUrl = $"/files/{fileName}";
            }

            var instructor = _mapper.Map<Instructor>(dto);
            instructor.ImageFile = imageUrl; 

            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();

            return await GetInstructorById(instructor.Id) ?? throw new Exception("Error creating instructor");
        }

        // ✅ Update Instructor
        public async Task<InstructorDto?> UpdateInstructor(UpdateInstructorDto dto)
        {
            var instructor = await _context.Instructors.FindAsync(dto.Id);
            if (instructor == null) return null;

            _mapper.Map(dto, instructor); // AutoMapper updates only non-null properties

            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                // Delete old image
                if (!string.IsNullOrEmpty(instructor.ImageFile))
                {
                    var oldPath = Path.Combine(_uploadPath, instructor.ImageFile.Replace("/files/", ""));
                    if (File.Exists(oldPath)) File.Delete(oldPath);
                }

                // Save new image
                var fileName = $"{Guid.NewGuid()}_{dto.ImageFile.FileName}";
                var filePath = Path.Combine(_uploadPath, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await dto.ImageFile.CopyToAsync(stream);

                instructor.ImageFile = $"/files/{fileName}";
            }

            await _context.SaveChangesAsync();
            return await GetInstructorById(instructor.Id);
        }

        // ✅ Delete Instructor
        public async Task<bool> DeleteInstructor(int id)
        {
            var instructor = await _context.Instructors
                .Include(i => i.Courses) // Include related courses
                .FirstOrDefaultAsync(i => i.Id == id);

            if (instructor == null) return false;

            // Check if the instructor has any courses
            if (instructor.Courses != null && instructor.Courses.Any())
            {
                // Cannot delete instructor assigned to a course
                return false;
            }

            if (!string.IsNullOrEmpty(instructor.ImageFile))
            {
                var fileName = instructor.ImageFile.Replace("/files/", "");
                var oldPath = Path.Combine(_uploadPath, fileName);

                if (File.Exists(oldPath))
                    File.Delete(oldPath);
            }

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<IEnumerable<InstructorDto>> GetAllInstructorsFiltered(
       int page = 1,
       int pageSize = 9,
       Expression<Func<InstructorDto, bool>>? filterExpression = null)
        {
            // Start with all instructors
            var query = _context.Instructors.AsQueryable();

            // Project to DTO
            var projected = query.Select(i => _mapper.Map<InstructorDto>(i));

            // Apply filter if provided
            if (filterExpression != null)
            {
                projected = projected.Where(filterExpression);
            }

            // Apply pagination
            projected = projected.Skip((page - 1) * pageSize).Take(pageSize);

            return await projected.ToListAsync();
        }
    }
}
