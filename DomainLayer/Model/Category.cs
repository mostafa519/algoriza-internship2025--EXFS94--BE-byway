using ByWay.DomainLayer.Enrollment;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace ByWay.DomainLayer.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Icon { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();

        public ICollection<InstructorCategory> CategoryInstructors { get; set; } = new List<InstructorCategory>();
        public ICollection<CategoryStudent> CategoryStudens { get; set; } = new List<CategoryStudent>();

    }
}