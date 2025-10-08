using ByWay.DomainLayer.Enums;
using System;
using System.Collections.Generic;

namespace ByWay.ServicesLayer.DTO
{
    public class RegisterModelDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public AccountType AccountType { get; set; }

        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        
    }
}
