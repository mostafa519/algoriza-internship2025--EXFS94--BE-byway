using System.ComponentModel.DataAnnotations;

namespace ByWay.DomainLayer.ModelAuth
{
    public class RegisterModel
    {
        [Required, StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required, StringLength(128)]
        public string Email { get; set; }= string.Empty;
         
    }
}