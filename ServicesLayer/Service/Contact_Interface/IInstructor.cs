using ByWay.ServicesLayer.DTO;
using System.Linq.Expressions;

namespace ByWay.ServicesLayer.Service.Contact_Interface
{
    public interface IInstructor
    {
        // Queries
        Task<IEnumerable<InstructorDto>> GetAllInstructors();
        Task<InstructorDto?> GetInstructorById(int id);
        Task<IEnumerable<InstructorDto>> GetInstructorsByName(string name);
        Task<IEnumerable<InstructorDto>> GetInstructorsByExpertise(string JobTitle);

        // Commands
        Task<InstructorDto> AddInstructor(CreateInstructorDto dto);
        Task<InstructorDto?> UpdateInstructor(UpdateInstructorDto dto);
        Task<bool> DeleteInstructor(int id);
        Task<IEnumerable<InstructorDto>> GetAllInstructorsFiltered(
           int page = 1,
           int pageSize = 9,
           Expression<Func<InstructorDto, bool>>? filterExpression = null);
    }
}
