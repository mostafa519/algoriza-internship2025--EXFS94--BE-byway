using ByWay.DomainLayer.Enrollment;
using ByWay.RepositoryLayer;
using ByWay.ServicesLayer.Service.Contact_Interface;
using Microsoft.EntityFrameworkCore; 

namespace ByWay.ServicesLayer.Service.Implementation
{
    public class FavoriteCourseService : IFavoriteCourseService
    {
        private readonly ApplicationDbContext _context;

        public FavoriteCourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add a course to a student's favorites
        public async Task<FavoriteCourseEnrollment> AddFavoriteAsync(int courseId, string studentId)
        {
            if (string.IsNullOrEmpty(studentId)) return null;

            var exists = await _context.FavoriteCourseEnrollments
                .AnyAsync(fc => fc.CourseId == courseId && fc.UserName == studentId);

            if (exists) return null; // Already favorited

            var favorite = new FavoriteCourseEnrollment
            {
                CourseId = courseId,
                UserName = studentId,
                CreatedAt = System.DateTime.UtcNow
            };

            _context.FavoriteCourseEnrollments.Add(favorite);
            await _context.SaveChangesAsync();

            // Return with related data
            return await _context.FavoriteCourseEnrollments
                .Include(fc => fc.Course) 
                .FirstOrDefaultAsync(fc => fc.CourseId == courseId && fc.UserName == studentId); ;
        }

        // Remove a course from a student's favorites
        public async Task<bool> RemoveFavoriteAsync(int courseId, string studentId)
        {
            var favorite = await _context.FavoriteCourseEnrollments
                .FirstOrDefaultAsync(fc => fc.CourseId == courseId && fc.UserName == studentId);

            if (favorite == null) return false;

            _context.FavoriteCourseEnrollments.Remove(favorite);
            await _context.SaveChangesAsync();
            return true;
        }

        // Check if a course is already favorited by a student
        public async Task<bool> IsFavoriteAsync(int courseId, string studentId)
        {
            return await _context.FavoriteCourseEnrollments
                .AnyAsync(fc => fc.CourseId == courseId && fc.UserName == studentId);
        }

        // Get all favorite courses for a student
        public async Task<IEnumerable<FavoriteCourseEnrollment>> GetFavoritesAsync(string studentId)
        {
            return await _context.FavoriteCourseEnrollments
                .Where(fc => fc.UserName == studentId)
                .Include(fc => fc.Course)
                .Include(fc => fc.Student)
                .ToListAsync();
        }
    }
}
