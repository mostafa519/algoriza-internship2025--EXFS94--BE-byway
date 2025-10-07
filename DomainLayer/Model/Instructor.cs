using ByWay.DomainLayer.Enrollment;
using System.ComponentModel.DataAnnotations;  

namespace ByWay.DomainLayer.Model
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string ImageFile { get; set; } // رابط أو اسم ملف صورة

        [Required, MaxLength(100)]
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; } 
          
        public ICollection<Course> Courses { get; set; } = new List<Course>();

        public ICollection<InstructorCategory> InstructorCategorys { get; set; } = new List<InstructorCategory>();
        public ICollection<InstructorStudent> InstructorStudents { get; set; } = new List<InstructorStudent>();

    }
}
