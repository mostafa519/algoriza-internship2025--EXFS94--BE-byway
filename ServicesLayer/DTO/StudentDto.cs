using ByWay.DomainLayer.Enums;
using System;
using System.Collections.Generic;

namespace ByWay.ServicesLayer.DTO
{
    public class StudentRegisterDto
    {
        // Basic info
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public AccountType AccountType { get; set; } = AccountType.Student;
        public string UserName { get; set; } = string.Empty;

        // Profile info
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;

        // Payment info
        public string CardName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public string CVC { get; set; } = string.Empty;
    }

    public class StudentLoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class StudentDto
    {
        // Basic info
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public AccountType AccountType { get; set; }

        // Profile
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;

        // Payment info (masked)
        public string CardName { get; set; } = string.Empty;
        public string MaskedCardNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }

        // Relations
        public List<string> Courses { get; set; } = new();
        public List<string> Instructors { get; set; } = new();
        public List<string> Categories { get; set; } = new();
    }
}
