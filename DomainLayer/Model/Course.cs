using ByWay.DomainLayer.Enrollment;
using ByWay.DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ByWay.DomainLayer.Model
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(300)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] // مهم لو هتخزن فلوس في SQL Server
        public decimal Price { get; set; }

        [Required]
        [Range(0, 5)] // التقييم غالبًا بيبقى من 0 لـ 5
        public double Rate { get; set; }

        public string ImageFile { get; set; } // رابط الصورة

        public int? DurationInHours { get; set; }
        public string? Level { get; set; }
        public int? LectureCount { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Relationships
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
        public ICollection<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
        public ICollection<FavoriteCourseEnrollment> CourseFavorites { get; set; } = new List<FavoriteCourseEnrollment>();

            }
}
