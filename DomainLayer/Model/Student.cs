using ByWay.DomainLayer.Enrollment;
using ByWay.DomainLayer.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ByWay.DomainLayer.Model
{
    public class Student : IdentityUser
    {
        //[Key]
        //public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(100)]
        public string UserName { get; set; } 
        [Required, EmailAddress]
        public string Email { get; set; }
        public AccountType AccountType { get; set; }
        public StudentProfile? Profile { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<CourseStudent> StudentCourses { get; set; } = new List<CourseStudent>();
        public ICollection<InstructorStudent> StudentInstructors { get; set; } = new List<InstructorStudent>();
        public ICollection<CategoryStudent> StudentCategorys { get; set; } = new List<CategoryStudent>();
        public ICollection<FavoriteCourseEnrollment> StudentFavoriteCourses { get; set; } = new List<FavoriteCourseEnrollment>();


    }
}
