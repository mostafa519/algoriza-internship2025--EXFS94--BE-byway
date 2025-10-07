using ByWay.DomainLayer.Model;
using ByWay.DomainLayer.ModelAuth;
using ByWay.ServicesLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ByWay.ServicesLayer.Service.Contact_Interface
{
    public interface IAuthService
    {
        // Register a user with a role
        Task<AuthModel> RegisterAsync(StudentRegisterDto model, string role);

        // Login and get token (generic)
        Task<AuthModel> GenerateJwtToken(Student model, string role = "");

        // Admin login
        Task<AuthModel> AdminLoginAsync(StudentLoginDto model);
        Task<List<StudentDto>> GetAllStudentsAsync();
        Task<AuthModel> UserLoginAsync(StudentLoginDto model, string role="");
        //// Add a role to a user
        //Task<string> AddRoleAsync(AddRoleModel model, string role);

        //// Optional: get all users
        //Task<IEnumerable<AppAdmin>> GetAllUsersAsync();

    }
}
