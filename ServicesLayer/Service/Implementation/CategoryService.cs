using ByWay.DomainLayer.Model;
using ByWay.RepositoryLayer;
using ByWay.ServicesLayer.Service.Contact_Interface;
using Microsoft.EntityFrameworkCore;

namespace ByWay.ServicesLayer.Service.Implementation
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses
                                 .Include(c => c.Category)
                                 .ToListAsync();
        }
    }
}
