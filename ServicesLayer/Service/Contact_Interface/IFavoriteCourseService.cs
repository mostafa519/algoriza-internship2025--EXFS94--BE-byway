using ByWay.DomainLayer.Enrollment;
using ByWay.DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByWay.ServicesLayer.Service.Contact_Interface
{
    public interface IFavoriteCourseService
    {
        Task<FavoriteCourseEnrollment> AddFavoriteAsync(string studentId, int courseId);
        Task<bool> RemoveFavoriteAsync(string studentId, int courseId);
        Task<List<Course>> GetUserFavoritesAsync(string studentId);
    }
}
