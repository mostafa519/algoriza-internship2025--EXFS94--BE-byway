using ByWay.DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByWay.ServicesLayer.Service.Contact_Interface
{
    public interface IStudentProfileService
    {
        Task<StudentProfile> GetProfileAsync(string studentId);
        Task<StudentProfile> CreateOrUpdateProfileAsync(StudentProfile profile);
    }
}
