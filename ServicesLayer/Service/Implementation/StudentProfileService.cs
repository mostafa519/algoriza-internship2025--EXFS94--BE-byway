using ByWay.DomainLayer.Model;
using ByWay.RepositoryLayer;
using ByWay.ServicesLayer.Service.Contact_Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ByWay.ServicesLayer.Service
{
    public class StudentProfileService : IStudentProfileService
    {
        private readonly ApplicationDbContext _context;

        public StudentProfileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StudentProfile> GetProfileAsync(string studentId)
        {
            return await _context.StudentProfiles.FirstOrDefaultAsync(p => p.UserName == studentId);
        }

        public async Task<StudentProfile> CreateOrUpdateProfileAsync(StudentProfile profile)
        {
            var existingProfile = await _context.StudentProfiles
                                                .FirstOrDefaultAsync(p => p.UserName == profile.UserName);
            if (existingProfile != null)
            {
                // تحديث البيانات
                existingProfile.Country = profile.Country;
                existingProfile.State = profile.State;
                existingProfile.CardName = profile.CardName;
                existingProfile.CardNumber = profile.CardNumber; // ⚠️ تشفير لاحقًا
                existingProfile.ExpiryDate = profile.ExpiryDate;
                existingProfile.CVC = profile.CVC; // ⚠️ تشفير لاحقًا
            }
            else
            {
                // إضافة جديد
                await _context.StudentProfiles.AddAsync(profile);
            }

            await _context.SaveChangesAsync();
            return profile;
        }
    }
}
