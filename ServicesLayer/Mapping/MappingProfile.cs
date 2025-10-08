using AutoMapper;
using ByWay.DomainLayer.Model;
using ByWay.ServicesLayer.DTO;

namespace ByWay.ServicesLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentRegisterDto, Student>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => new StudentProfile
                {
                    Country = src.Country,
                    State = src.State,
                    CardName = src.CardName,
                    CardNumber = src.CardNumber,
                    ExpiryDate = src.ExpiryDate,
                }));

            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => src.AccountType))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Profile != null ? src.Profile.Country : ""))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Profile != null ? src.Profile.State : ""))
                .ForMember(dest => dest.CardName, opt => opt.MapFrom(src => src.Profile != null ? src.Profile.CardName : "")); 
        }
    }
}
