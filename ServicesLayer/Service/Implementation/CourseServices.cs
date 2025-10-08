using AutoMapper;
using ByWay.DomainLayer.Model;
using ByWay.RepositoryLayer;
using ByWay.ServicesLayer.DTO;
using ByWay.ServicesLayer.Service.Contact_Interface; 
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace ByWay.ServicesLayer.Service.Implementation
{
    public class CourseServices : ICourse
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _uploadPath;

        public CourseServices(ApplicationDbContext context, IMapper mapper, string uploadPath)
        {
            _context = context;
            _mapper = mapper;
            _uploadPath = uploadPath;

            if (!Directory.Exists(_uploadPath))
                Directory.CreateDirectory(_uploadPath);
        }

        // ✅ Get All Courses
        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            var courses = await _context.Courses
                .Include(c => c.Category)
                .Include(c => c.Instructor)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        // ✅ Get Course By Id
        public async Task<CourseDto?> GetCourseById(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Category)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(c => c.Id == id);

            return course == null ? null : _mapper.Map<CourseDto>(course);
        }

        // ✅ Get Course By Name
        public async Task<CourseDto?> GetCourseByName(string name)
        {
            var course = await _context.Courses
                .FirstOrDefaultAsync(c => c.Name.Contains(name));

            return course == null ? null : _mapper.Map<CourseDto>(course);
        }

        // ✅ Get Courses By Price
        public async Task<IEnumerable<CourseDto>> GetCoursesByPrice(decimal price)
        {
            var courses = await _context.Courses
                .Include(c => c.Category)
                .Include(c => c.Instructor)
                .Where(c => c.Price == price)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        // ✅ Get Courses By Duration
        public async Task<IEnumerable<CourseDto>> GetCoursesByDuration(int duration)
        {
            var courses = await _context.Courses
                .Where(c => c.DurationInHours == duration)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        // ✅ Get Courses By Category Name
        public async Task<IEnumerable<CourseDto>> GetCoursesByCategory(string category)
        {
            var courses = await _context.Courses
                .Where(c => c.Category != null && c.Category.Name.Contains(category))
                .ToListAsync();

            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        // ✅ Get Courses By Rate
        public async Task<IEnumerable<CourseDto>> GetCoursesByRate(double rate)
        {
            var courses = await _context.Courses
                .Where(c => c.Rate == rate)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        // ✅ Get Courses By Level
        public async Task<IEnumerable<CourseDto>> GetCoursesByLevel(string level)
        {
            var courses = await _context.Courses
                .Where(c => c.Level == level)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        // ✅ Add Course
        public async Task<CourseDto> AddCourse(CreateCourseDto dto)
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

            var course = _mapper.Map<Course>(dto);
            course.ImageFile = imageUrl;

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return await GetCourseById(course.Id) ?? throw new Exception("Error creating course");
        }

        // ✅ Update Course
        public async Task<CourseDto?> UpdateCourse(UpdateCourseDto dto)
        {
            var course = await _context.Courses.FindAsync(dto.Id);
            if (course == null) return null;

            // Map only non-null properties
            _mapper.Map(dto, course);

            // Handle Image
            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                if (!string.IsNullOrEmpty(course.ImageFile))
                {
                    var oldPath = Path.Combine(_uploadPath, course.ImageFile.Replace("/files/", ""));
                    if (File.Exists(oldPath)) File.Delete(oldPath);
                }

                var fileName = $"{Guid.NewGuid()}_{dto.ImageFile.FileName}";
                var filePath = Path.Combine(_uploadPath, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await dto.ImageFile.CopyToAsync(stream);

                course.ImageFile = $"/files/{fileName}";
            }

            await _context.SaveChangesAsync();
            return await GetCourseById(course.Id);
        }

        // ✅ Delete Course
        public async Task<bool> DeleteCourse(int id)
        {
            var course = await _context.Courses
                .Include(c => c.CourseStudents)    // Include students
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null) return false;

            // Check if course has any students or instructors
            if (course.CourseStudents != null && course.CourseStudents.Any())
            {
                // Cannot delete
                return false;
            }

            if (!string.IsNullOrEmpty(course.ImageFile))
            {
                var oldPath = Path.Combine(_uploadPath, course.ImageFile.Replace("/files/", ""));
                if (File.Exists(oldPath)) File.Delete(oldPath);
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCoursesFiltered(
       int page = 1,
       int pageSize = 9,
       Expression<Func<CourseDto, bool>>? filterExpression = null)
        {
            // Start with all courses
            var query = _context.Courses.AsQueryable();

            // Project to DTO
            var projected = query.Select(c => _mapper.Map<CourseDto>(c));

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
