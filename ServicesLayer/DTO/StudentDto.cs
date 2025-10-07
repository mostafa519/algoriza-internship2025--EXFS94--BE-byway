using ByWay.DomainLayer.Enums;
using System;
using System.Collections.Generic;

namespace ByWay.ServicesLayer.DTO
{
 
    public class StudentDto
    {
        // بيانات أساسية
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; }
        public string Email { get; set; } = string.Empty;
        public AccountType AccountType { get; set; }

        // بيانات Profile
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;

        // معلومات الدفع (مع التشفير / العرض الجزئي)
        public string CardName { get; set; } = string.Empty;
        public string MaskedCardNumber { get; set; } = string.Empty;
        public string ExpiryDate { get; set; } = string.Empty;

        // علاقات
        public List<string> Courses { get; set; } = new();
        public List<string> Instructors { get; set; } = new();
        public List<string> Categories { get; set; } = new();
    }
    public class StudentRegisterDto
    {
        // بيانات أساسية
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }= string.Empty;
        public string Password { get; set; } = string.Empty;
        public AccountType AccountType { get; set; }

        public string UserName { get; set; }
        // بيانات Profile
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;

        // معلومات الدفع
        public string CardName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string ExpiryDate { get; set; }= string.Empty;
        public string CVC { get; set; } = string.Empty;
    }

    
    public class StudentLoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
