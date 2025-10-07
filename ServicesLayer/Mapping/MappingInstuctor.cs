using AutoMapper;
using ByWay.DomainLayer.Model;
using ByWay.ServicesLayer.DTO;

namespace ByWay.ServicesLayer.Mapping
{
    public class MappingInstructor : Profile
    {
        public MappingInstructor()
        {
            CreateMap<Instructor, InstructorDto>()
               .ForMember(dest => dest.CourseNames,
                          opt => opt.MapFrom(src => src.Courses != null
                              ? src.Courses.Select(c => c.Name).ToList()
                              : new List<string>()))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.ImageFile, opt => opt.MapFrom(src => src.ImageFile))
               .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate));

            // CreateInstructorDto -> Instructor
            CreateMap<CreateInstructorDto, Instructor>();

            // UpdateInstructorDto -> Instructor
            CreateMap<UpdateInstructorDto, Instructor>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
    }
 
