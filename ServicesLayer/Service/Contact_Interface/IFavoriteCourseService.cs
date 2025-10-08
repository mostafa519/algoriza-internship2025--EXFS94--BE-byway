using ByWay.DomainLayer.Enrollment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ByWay.ServicesLayer.Service.Contact_Interface
{
    public interface IFavoriteCourseService
    {  
        Task<FavoriteCourseEnrollment> AddFavoriteAsync(int courseId, string studentId);
         
        Task<bool> RemoveFavoriteAsync(int courseId, string studentId);
         
        Task<bool> IsFavoriteAsync(int courseId, string studentId); 
        Task<IEnumerable<FavoriteCourseEnrollment>> GetFavoritesAsync(string studentId);
    }
}
