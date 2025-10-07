using ByWay.DomainLayer.Model; 

namespace ByWay.ServicesLayer.Service.Contact_Interface
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();  
        Task<IEnumerable<Course>> GetAllCoursesAsync();        
    }
}
