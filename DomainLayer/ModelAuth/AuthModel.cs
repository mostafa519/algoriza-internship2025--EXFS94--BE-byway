using ByWay.DomainLayer.Enums;
using System;
using System.Collections.Generic;

namespace ByWay.DomainLayer.ModelAuth
{
    public class AuthModel
    {
        // ✅ الحالة العامة للمصادقة
        public bool IsAuthenticated { get; set; }

        // ✅ رسالة للتوضيح (نجاح / فشل)
        public string Message { get; set; } = string.Empty;

        // ✅ بيانات المستخدم
        public string UserId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public AccountType AccountType { get; set; }

        // ✅ الأدوار (Roles)
        public List<string> Roles { get; set; } = new();

        // ✅ بيانات التوكن
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresOn { get; set; }

        // ✅ دعم Refresh Token (اختياري)
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
    }
}
