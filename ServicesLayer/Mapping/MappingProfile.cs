using AutoMapper;
using ByWay.DomainLayer.Model;
using ByWay.DomainLayer.ModelAuth;
using ByWay.ServicesLayer.DTO;

namespace ByWay.ServicesLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // RegisterModelDTO -> StudentRegisterDto
            CreateMap<RegisterModelDTO, StudentRegisterDto>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            // RegisterModelDTO -> Student
            CreateMap<RegisterModelDTO, Student>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // Student -> StudentDto
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => src.AccountType));

            // StudentProfile -> StudentProfileDto
            CreateMap<StudentProfile, StudentProfileDto>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.CardName, opt => opt.MapFrom(src => src.CardName))
                .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => src.CardNumber))
                .ForMember(dest => dest.ExpiryDate, opt => opt.MapFrom(src => src.ExpiryDate))
                .ForMember(dest => dest.CVC, opt => opt.MapFrom(src => src.CVC));
        }
    }
}
