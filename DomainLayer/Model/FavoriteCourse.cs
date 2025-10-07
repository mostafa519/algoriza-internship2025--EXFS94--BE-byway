using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByWay.DomainLayer.Model
{
    public class FavoriteCourse
    {
        public int Id { get; set; }
        public string StudentId { get; set; }               // المستخدم
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // علاقة الكورسات
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
