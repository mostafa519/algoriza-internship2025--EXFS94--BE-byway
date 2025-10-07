using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ByWay.ServicesLayer.DTO
{
    /// <summary>
    /// عرض بيانات المدرس
    /// </summary>
    public class InstructorDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? ImageFile { get; set; }

        public string JobTitle { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Rate { get; set; }

        // =================== Relations ===================
        public List<string>? CourseNames { get; set; } = new List<string>();
        public List<string>? CategoryNames { get; set; } = new List<string>();
        public int StudentCount { get; set; } = 0;
    }

    /// <summary>
    /// إنشاء مدرس جديد
    /// </summary>
    public class CreateInstructorDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public IFormFile? ImageFile { get; set; }

        [Required, MaxLength(100)]
        public string JobTitle { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Range(0, 5)]
        public double Rate { get; set; } = 0;

        // =================== Relations ===================
        public List<int>? CategoryIds { get; set; } = new List<int>();
        public List<int>? CourseIds { get; set; } = new List<int>();
        public List<int>? StudentIds { get; set; } = new List<int>();
    }

     
    public class UpdateInstructorDto
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        public IFormFile? ImageFile { get; set; }

        [MaxLength(100)]
        public string? JobTitle { get; set; }

        public string? Description { get; set; }

        [Range(0, 5)]
        public double? Rate { get; set; }

        // =================== Relations ===================
        public List<int>? CategoryIds { get; set; }
        public List<int>? CourseIds { get; set; }
        public List<int>? StudentIds { get; set; }
    }
}
