using ByWay.DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByWay.DomainLayer.Enrollment
{
    public class InstructorStudent
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Instructor))]
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}
