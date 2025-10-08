using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByWay.DomainLayer.Model
{
    public class StudentProfile
    { 
        [Key]
        [ForeignKey("Student")]
        public string UserName { get; set; }

        // =================== Location ===================
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        [MaxLength(100)]
        public string State { get; set; } = string.Empty; 
        [Required, MaxLength(100)]
        public string CardName { get; set; } = string.Empty;

        [Required, CreditCard]
        public string CardNumber { get; set; } = string.Empty;

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required, MaxLength(4)]
        public int CVC { get; set; }  
        public Student Student { get; set; }
    }
}
