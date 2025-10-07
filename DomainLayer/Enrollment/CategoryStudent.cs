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
    public class CategoryStudent
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}
