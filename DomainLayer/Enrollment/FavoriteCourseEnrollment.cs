using ByWay.DomainLayer.Model;
using ByWay.DomainLayer.ModelAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByWay.DomainLayer.Enrollment
{
    public class FavoriteCourseEnrollment
    {
        public string UserName { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
