using ByWay.DomainLayer.Enums;
using ByWay.DomainLayer.Model;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ByWay.DomainLayer.ModelAuth
{
    public class AppAdmin : IdentityUser
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; } 

        [Required, MaxLength(100)]
        public string LastName { get; set; } 
        public AccountType AccountType { get; set; }
         
        public DateTime EnrollmentDate { get; set; }  
        public string? Department { get; set; }   // Admin-only
         
        public bool IsSuperAdmin { get; set; } = false;

        
    }
}
