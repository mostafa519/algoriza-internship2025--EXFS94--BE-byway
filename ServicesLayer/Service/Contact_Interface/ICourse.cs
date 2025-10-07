using ByWay.ServicesLayer.DTO;
using System.Linq.Expressions;

namespace ByWay.ServicesLayer.Service.Contact_Interface
{
    public interface ICourse
    {
        Task<IEnumerable<CourseDto>> GetAllCourses();
        Task<CourseDto?> GetCourseByName(string name);
        Task<CourseDto?> GetCourseById(int id);
        Task<IEnumerable<CourseDto>> GetCoursesByPrice(decimal price);
        Task<IEnumerable<CourseDto>> GetCoursesByDuration(int duration);
        Task<IEnumerable<CourseDto>> GetCoursesByCategory(string category);
        Task<IEnumerable<CourseDto>> GetCoursesByRate(double rate);
        Task<IEnumerable<CourseDto>> GetCoursesByLevel(string level);

        Task<CourseDto> AddCourse(CreateCourseDto dto);
        Task<CourseDto?> UpdateCourse(UpdateCourseDto dto);
        Task<bool> DeleteCourse(int id);

        Task<IEnumerable<CourseDto>> GetAllCoursesFiltered(
            int page = 1,
            int pageSize = 9,
            Expression<Func<CourseDto, bool>>? filterExpression = null);


    }
}
