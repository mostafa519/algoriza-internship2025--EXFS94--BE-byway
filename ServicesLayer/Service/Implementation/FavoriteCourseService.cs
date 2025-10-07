using ByWay.DomainLayer.Enrollment;
using ByWay.DomainLayer.Model;
using ByWay.RepositoryLayer;
using ByWay.ServicesLayer.Service.Contact_Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByWay.ServicesLayer.Service.Implementation
{
    public class FavoriteCourseService : IFavoriteCourseService
    {
        private readonly ApplicationDbContext _context;

        public FavoriteCourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FavoriteCourseEnrollment> AddFavoriteAsync(string studentId, int courseId)
        {
            var exists = await _context.FavoriteCourseEnrollments
                .AnyAsync(fc => fc.StudentId == studentId && fc.CourseId == courseId);

            if (exists) return null; // Already exists

            var favorite = new FavoriteCourseEnrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                CreatedAt = System.DateTime.UtcNow
            };

            _context.FavoriteCourseEnrollments.Add(favorite);
            await _context.SaveChangesAsync();

            return favorite;
        }

        public async Task<bool> RemoveFavoriteAsync(string studentId, int courseId)
        {
            var favorite = await _context.FavoriteCourseEnrollments
                .FirstOrDefaultAsync(fc => fc.StudentId == studentId && fc.CourseId == courseId);

            if (favorite == null) return false;

            _context.FavoriteCourseEnrollments.Remove(favorite);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Course>> GetUserFavoritesAsync(string studentId)
        {
            return await _context.FavoriteCourseEnrollments
                .Where(fc => fc.StudentId == studentId)
                .Include(fc => fc.Course)
                .Select(fc => fc.Course)
                .ToListAsync();
        }
    }
}
