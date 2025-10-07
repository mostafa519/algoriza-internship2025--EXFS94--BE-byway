using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ByWay.ServicesLayer.DTO
{
    /// <summary>
    /// عرض بيانات الكورس
    /// </summary>
    public class CourseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public double Rate { get; set; }

        public string? ImageFile { get; set; }

        public int DurationInHours { get; set; }

        public string Level { get; set; } = string.Empty;

        public int LectureCount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // Relations
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public int InstructorId { get; set; }
        public string InstructorName { get; set; } = string.Empty;
    }

    /// <summary>
    /// إنشاء كورس جديد
    /// </summary>
    public class CreateCourseDto
    {
        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required, Range(0, 10000)]
        public decimal Price { get; set; }

        [Range(0, 5)]
        public double Rate { get; set; } = 0;

        public IFormFile? ImageFile { get; set; }

        [Required, Range(1, 1000)]
        public int DurationInHours { get; set; }

        [Required, MaxLength(50)]
        public string Level { get; set; } = string.Empty;

        [Required, Range(1, 500)]
        public int LectureCount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        // Relations
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int InstructorId { get; set; }
    }

    /// <summary>
    /// تحديث بيانات الكورس
    /// </summary>
    public class UpdateCourseDto
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(150)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Range(0, 10000)]
        public decimal? Price { get; set; }

        [Range(0, 5)]
        public double? Rate { get; set; }

        public IFormFile? ImageFile { get; set; }

        [Range(1, 1000)]
        public int? DurationInHours { get; set; }

        [MaxLength(50)]
        public string? Level { get; set; }

        [Range(1, 500)]
        public int? LectureCount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? CategoryId { get; set; }

        public int? InstructorId { get; set; }
    }
}
