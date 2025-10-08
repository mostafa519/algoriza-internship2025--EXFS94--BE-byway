using ByWay.DomainLayer.Enrollment;
using ByWay.DomainLayer.Model;
using ByWay.DomainLayer.ModelAuth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using YourProject.Context;

namespace ByWay.RepositoryLayer
{
    public class ApplicationDbContext : IdentityDbContext<Student>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }

        // ✅ Join Tables
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<InstructorStudent> InstructorStudents { get; set; }
        public DbSet<CategoryStudent> CategoryStudents { get; set; }
        public DbSet<InstructorCategory> InstructorCategories { get; set; }
        public DbSet<FavoriteCourseEnrollment> FavoriteCourseEnrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ✅ Composite Keys & Relationships

            builder.Entity<CourseStudent>()
                .HasKey(cs => new { cs.CourseId, cs.StudentId });

            builder.Entity<CourseStudent>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(cs => cs.CourseId);

            builder.Entity<CourseStudent>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(cs => cs.StudentId);


            builder.Entity<InstructorStudent>()
                .HasKey(isr => new { isr.InstructorId, isr.StudentId });

            builder.Entity<InstructorStudent>()
                .HasOne(isr => isr.Instructor)
                .WithMany(i => i.InstructorStudents)
                .HasForeignKey(isr => isr.InstructorId);

            builder.Entity<InstructorStudent>()
                .HasOne(isr => isr.Student)
                .WithMany(s => s.StudentInstructors)
                .HasForeignKey(isr => isr.StudentId);


            builder.Entity<CategoryStudent>()
                .HasKey(cs => new { cs.CategoryId, cs.StudentId });

            builder.Entity<CategoryStudent>()
                .HasOne(cs => cs.Category)
                .WithMany(c => c.CategoryStudens)
                .HasForeignKey(cs => cs.CategoryId);

            builder.Entity<CategoryStudent>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.StudentCategorys)
                .HasForeignKey(cs => cs.StudentId);


            builder.Entity<InstructorCategory>()
                .HasKey(ic => new { ic.InstructorId, ic.CategoryId });

            builder.Entity<InstructorCategory>()
                .HasOne(ic => ic.Instructor)
                .WithMany(i => i.InstructorCategorys)
                .HasForeignKey(ic => ic.InstructorId);

            builder.Entity<InstructorCategory>()
                .HasOne(ic => ic.Category)
                .WithMany(c => c.CategoryInstructors)
                .HasForeignKey(ic => ic.CategoryId);
            //////
            builder.Entity<FavoriteCourseEnrollment>()
                .HasKey(fc => new { fc.UserName, fc.CourseId });

            builder.Entity<FavoriteCourseEnrollment>()
                .HasOne(fc => fc.Student)
                .WithMany(u => u.StudentFavoriteCourses)
                .HasForeignKey(fc => fc.UserName);

            builder.Entity<FavoriteCourseEnrollment>()
                .HasOne(fc => fc.Course)
                .WithMany(c => c.CourseFavorites)
                .HasForeignKey(fc => fc.CourseId);


            // ✅ Seeding
            SeedingData.SeedAll(builder);
        }
    }
}
