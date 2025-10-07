using AutoMapper;
using ByWay.ServicesLayer.DTO;
using ByWay.DomainLayer.Model;

namespace ByWay.ServicesLayer.Mapping
{
    public class MappingCourse : Profile
    {
        public MappingCourse()
        {
            CreateMap<Course, CourseDto>()
                 .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
                 .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Instructor != null ? src.Instructor.Name : string.Empty))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                 .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                 .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate))
                 .ForMember(dest => dest.ImageFile, opt => opt.MapFrom(src => src.ImageFile))
                 .ForMember(dest => dest.DurationInHours, opt => opt.MapFrom(src => src.DurationInHours))
                 .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level))
                 .ForMember(dest => dest.LectureCount, opt => opt.MapFrom(src => src.LectureCount))
                 .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                 .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

            // CreateCourseDto -> Course
            CreateMap<CreateCourseDto, Course>();

            // UpdateCourseDto -> Course
            CreateMap<UpdateCourseDto, Course>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
