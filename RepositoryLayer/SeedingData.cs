using ByWay.DomainLayer.Enrollment;
using ByWay.DomainLayer.Enums;
using ByWay.DomainLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace YourProject.Context
{
    public static class SeedingData
    {
        // ---------------- Roles ----------------
        public static void SeedRoles(ModelBuilder builder)
        {
            var roles = new List<IdentityRole>
            {
                new IdentityRole { Id = "11111111-1111-1111-1111-111111111111", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "22222222-2222-2222-2222-222222222222", Name = "Student", NormalizedName = "STUDENT" }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }

        // ---------------- Users ----------------
        public static void SeedUsers(ModelBuilder builder)
        {
            var passwordHasher = new PasswordHasher<Student>();

            var admin = new Student
            {
                Id = "b2c3d4e5-f6a7-8901-bcde-234567890abc",
                UserName = "admin@byway.com",
                NormalizedUserName = "ADMIN@BYWAY.COM",
                Email = "admin@byway.com",
                NormalizedEmail = "ADMIN@BYWAY.COM",
                EmailConfirmed = true,
                FirstName = "System",
                LastName = "Admin",
                AccountType = AccountType.Admin
            };
            admin.PasswordHash = passwordHasher.HashPassword(admin, "admin1234");

            var student1 = new Student
            {
                Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                FirstName = "Mustafa",
                LastName = "Ali",
                UserName = "mustafa",
                NormalizedUserName = "MUSTAFA",
                Email = "mustafa.ali@example.com",
                NormalizedEmail = "MUSTAFA.ALI@EXAMPLE.COM",
                EmailConfirmed = true,
                AccountType = AccountType.Student
            };
            student1.PasswordHash = passwordHasher.HashPassword(student1, "Student@2584");

            var student2 = new Student
            {
                Id = "4fa85f64-5717-4562-b3fc-2c963f66afa7",
                FirstName = "John",
                LastName = "Doe",
                UserName = "johndoe",
                NormalizedUserName = "JOHNDOE",
                Email = "john.doe@example.com",
                NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
                EmailConfirmed = true,
                AccountType = AccountType.Student
            };
            student2.PasswordHash = passwordHasher.HashPassword(student2, "Student@2584");

            builder.Entity<Student>().HasData(admin, student1, student2);

            // ---------------- Assign Roles ----------------
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = admin.Id, RoleId = "11111111-1111-1111-1111-111111111111" },
                new IdentityUserRole<string> { UserId = student1.Id, RoleId = "22222222-2222-2222-2222-222222222222" },
                new IdentityUserRole<string> { UserId = student2.Id, RoleId = "22222222-2222-2222-2222-222222222222" }
            );
        }

        // ---------------- Categories ----------------
        public static void SeedCategories(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Development", Icon = "fa-laptop-code" },
                new Category { Id = 2, Name = "Design", Icon = "fa-paint-brush" },
                new Category { Id = 3, Name = "Education", Icon = "fa-book" },
                new Category { Id = 4, Name = "Music", Icon = "fa-music" },
                new Category { Id = 5, Name = "Photography", Icon = "fa-camera" },
                new Category { Id = 6, Name = "Fitness", Icon = "fa-dumbbell" },
                new Category { Id = 7, Name = "Travel", Icon = "fa-globe" },
                new Category { Id = 8, Name = "Health", Icon = "fa-heart" },
                new Category { Id = 9, Name = "Movies", Icon = "fa-film" },
                new Category { Id = 10, Name = "Programming", Icon = "fa-code" }
            );
        }

        // ---------------- Instructors ----------------
        public static void SeedInstructors(ModelBuilder builder)
        {
            builder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, Name = "Ali Hassan", JobTitle = "Frontend Developer", Description = "Specialist in React and modern JavaScript frameworks.", Rate = 4.8, ImageFile = "https://tse4.mm.bing.net/th/id/OIP.nkt3lTa7B747RqrCP8mdQAHaHa?rs=1&pid=ImgDetMain&o=7&rm=3" },
                new Instructor { Id = 2, Name = "Mustafa Ali", JobTitle = "Full-Stack Developer", Description = "Expert in both frontend and backend technologies.", Rate = 4.9, ImageFile = "https://tse4.mm.bing.net/th/id/OIP.nkt3lTa7B747RqrCP8mdQAHaHa?rs=1&pid=ImgDetMain&o=7&rm=3" },
                new Instructor { Id = 3, Name = "Ahmed Ali", JobTitle = "Backend Developer", Description = "Expert in APIs, microservices, and .NET 8.", Rate = 4.7, ImageFile = "https://tse4.mm.bing.net/th/id/OIP.nkt3lTa7B747RqrCP8mdQAHaHa?rs=1&pid=ImgDetMain&o=7&rm=3" },
                new Instructor { Id = 4, Name = "Eslam Mohamed", JobTitle = "UI/UX Designer", Description = "Designs stunning and user-friendly interfaces.", Rate = 4.6, ImageFile = "https://img.freepik.com/premium-vector/teacher-cartoon-illustration-with-sign_1120558-20344.jpg?w=2000" },
                new Instructor { Id = 5, Name = "Sara Khalid", JobTitle = "Data Scientist", Description = "Specialist in Python, Machine Learning, and AI.", Rate = 4.8, ImageFile = "https://img.freepik.com/premium-vector/teacher-cartoon-illustration-with-sign_1120558-20344.jpg?w=2000" },
                new Instructor { Id = 6, Name = "Hassan Omar", JobTitle = "DevOps Engineer", Description = "Expert in CI/CD, Docker, and Kubernetes.", Rate = 4.7, ImageFile = "https://img.freepik.com/premium-vector/teacher-cartoon-illustration-with-sign_1120558-20344.jpg?w=2000" },
                new Instructor { Id = 7, Name = "Laila Samir", JobTitle = "Mobile Developer", Description = "Builds iOS and Android apps with Flutter and React Native.", Rate = 4.5, ImageFile = "https://s3.amazonaws.com/coursesity-blog/2023/12/Mobile_Development_Courses.jpg" },
                new Instructor { Id = 8, Name = "Omar Adel", JobTitle = "Python Developer", Description = "Focuses on Python, Django, and automation.", Rate = 4.6, ImageFile = "https://img.freepik.com/premium-vector/teacher-cartoon-illustration-with-sign_1120558-20344.jpg?w=2000" },
                new Instructor { Id = 9, Name = "Mona Fathi", JobTitle = "Graphic Designer", Description = "Creates stunning visuals and brand identities.", Rate = 4.7, ImageFile = "https://img.freepik.com/premium-vector/teacher-presenting-lesson-front-green-chalkboard_126712-18933.jpg?w=2000" },
                new Instructor { Id = 10, Name = "Khaled Youssef", JobTitle = "Java Developer", Description = "Specialist in Java, Spring Boot, and backend architectures.", Rate = 4.8, ImageFile = "https://img.freepik.com/premium-vector/teacher-presenting-lesson-front-green-chalkboard_126712-18933.jpg?w=2000" },
                new Instructor { Id = 11, Name = "Fatma Hany", JobTitle = "SEO Expert", Description = "Optimizes websites for search engines and traffic growth.", Rate = 4.5, ImageFile = "https://img.freepik.com/premium-vector/teacher-presenting-lesson-front-green-chalkboard_126712-18933.jpg?w=2000" },
                new Instructor { Id = 12, Name = "Youssef Samir", JobTitle = "Cloud Architect", Description = "Expert in AWS, Azure, and scalable cloud solutions.", Rate = 4.7, ImageFile = "https://img.freepik.com/premium-vector/teacher-presenting-lesson-front-green-chalkboard_126712-18933.jpg?w=2000" },
                new Instructor { Id = 13, Name = "Nada Ahmed", JobTitle = "Cybersecurity Specialist", Description = "Focus on network security and ethical hacking.", Rate = 4.6, ImageFile = "https://img.freepik.com/premium-vector/teacher-presenting-lesson-front-green-chalkboard_126712-18933.jpg?w=2000" },
                new Instructor { Id = 14, Name = "Mahmoud Tarek", JobTitle = "AI Engineer", Description = "Builds AI models and intelligent systems.", Rate = 4.9, ImageFile = "https://img.freepik.com/premium-vector/teacher-presenting-lesson-front-green-chalkboard_126712-18933.jpg?w=2000" },
                new Instructor { Id = 15, Name = "Salma Fawzy", JobTitle = "Video Editor", Description = "Expert in Premiere Pro, After Effects, and video production.", Rate = 4.5, ImageFile = "https://tse4.mm.bing.net/th/id/OIP.mCRDsfv9LcGpqRuglQ7ZxQHaFj?w=626&h=470&rs=1&pid=ImgDetMain&o=7&rm=3" },
                new Instructor { Id = 16, Name = "John Doe", JobTitle = "Senior Full Stack Developer", Description = "Experienced in building scalable web applications using ASP.NET Core and React.", Rate = 4.8, ImageFile = "https://tse4.mm.bing.net/th/id/OIP.mCRDsfv9LcGpqRuglQ7ZxQHaFj?w=626&h=470&rs=1&pid=ImgDetMain&o=7&rm=3" },
                new Instructor { Id = 17, Name = "Jane Smith", JobTitle = "UI/UX Designer", Description = "Specialist in UI/UX optimization for modern apps.", Rate = 4.6, ImageFile = "https://tse4.mm.bing.net/th/id/OIP.mCRDsfv9LcGpqRuglQ7ZxQHaFj?w=626&h=470&rs=1&pid=ImgDetMain&o=7&rm=3" },
                new Instructor { Id = 18, Name = "Ahmed Ali", JobTitle = "Backend Developer", Description = "Expert in APIs, microservices, and .NET 8.", Rate = 4.7, ImageFile = "https://tse4.mm.bing.net/th/id/OIP.mCRDsfv9LcGpqRuglQ7ZxQHaFj?w=626&h=470&rs=1&pid=ImgDetMain&o=7&rm=3" },
                new Instructor { Id = 19, Name = "Sara Johnson", JobTitle = "Frontend Developer", Description = "Focused on crafting responsive React apps.", Rate = 4.5, ImageFile = "https://tse4.mm.bing.net/th/id/OIP.mCRDsfv9LcGpqRuglQ7ZxQHaFj?w=626&h=470&rs=1&pid=ImgDetMain&o=7&rm=3" }
            );
        }


        // ---------------- Courses ----------------
        public static void SeedCourses(ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Full Stack Web Development", Description = "Learn full stack development with React & .NET.", Price = 199.99m, Rate = 4.8, ImageFile = "https://tse3.mm.bing.net/th/id/OIP.OlilRMMjyjCRGtmJmgUZ5wHaEK", DurationInHours = 60, Level = "Intermediate", LectureCount = 45, StartDate = new DateTime(2025, 1, 10), EndDate = new DateTime(2025, 3, 20), CategoryId = 1, InstructorId = 1 },
                new Course { Id = 2, Name = "UI/UX Design Principles", Description = "Master the fundamentals of UI/UX design.", Price = 149.99m, Rate = 4.6, ImageFile = "https://www.excelptp.com/wp-content/uploads/2023/01/ui-ux-banner-img2.jpg", DurationInHours = 40, Level = "Beginner", LectureCount = 30, StartDate = new DateTime(2025, 2, 1), EndDate = new DateTime(2025, 3, 15), CategoryId = 2, InstructorId = 2 },
                new Course { Id = 3, Name = "UI/UX Design", Description = "Design stunning and user-friendly interfaces.", Price = 39.0m, Rate = 3, ImageFile = "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", DurationInHours = 15, Level = "Intermediate", LectureCount = 12, StartDate = new DateTime(2025, 4, 1), EndDate = new DateTime(2025, 4, 16), CategoryId = 2, InstructorId = 2 },
                new Course { Id = 4, Name = "Full-Stack Development", Description = "Become a full-stack developer using modern technologies.", Price = 79.0m, Rate = 5, ImageFile = "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", DurationInHours = 40, Level = "Advanced", LectureCount = 25, StartDate = new DateTime(2025, 5, 1), EndDate = new DateTime(2025, 6, 10), CategoryId = 1, InstructorId = 1 },
                new Course { Id = 5, Name = "React for Beginners", Description = "Learn the basics of React and build dynamic web apps.", Price = 49.0m, Rate = 4, ImageFile = "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", DurationInHours = 20, Level = "Beginner", LectureCount = 15, StartDate = new DateTime(2025, 6, 1), EndDate = new DateTime(2025, 6, 21), CategoryId = 1, InstructorId = 2 },
                new Course { Id = 6, Name = "Advanced JavaScript", Description = "Master JavaScript with advanced concepts and best practices.", Price = 59.0m, Rate = 5, ImageFile = "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", DurationInHours = 25, Level = "Advanced", LectureCount = 18, StartDate = new DateTime(2025, 6, 5), EndDate = new DateTime(2025, 6, 30), CategoryId = 1, InstructorId = 1 },
                new Course { Id = 7, Name = "UI/UX Design", Description = "Design stunning and user-friendly interfaces.", Price = 39.0m, Rate = 3, ImageFile = "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", DurationInHours = 15, Level = "Intermediate", LectureCount = 12, StartDate = new DateTime(2025, 7, 1), EndDate = new DateTime(2025, 7, 16), CategoryId = 2, InstructorId = 3 },
                new Course { Id = 8, Name = "Full-Stack Development", Description = "Become a full-stack developer using modern technologies.", Price = 79.0m, Rate = 5, ImageFile = "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", DurationInHours = 40, Level = "Advanced", LectureCount = 25, StartDate = new DateTime(2025, 7, 10), EndDate = new DateTime(2025, 8, 20), CategoryId = 1, InstructorId = 4 },
                new Course { Id = 9, Name = "Angular Basics", Description = "Get started with Angular and build single-page applications.", Price = 45.0m, Rate = 4, ImageFile = "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", DurationInHours = 18, Level = "Beginner", LectureCount = 14, StartDate = new DateTime(2025, 8, 1), EndDate = new DateTime(2025, 8, 20), CategoryId = 1, InstructorId = 2 },
                new Course { Id = 10, Name = "Node.js Essentials", Description = "Learn backend development with Node.js and Express.", Price = 55.0m, Rate = 5, ImageFile = "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", DurationInHours = 22, Level = "Intermediate", LectureCount = 17, StartDate = new DateTime(2025, 8, 5), EndDate = new DateTime(2025, 8, 30), CategoryId = 1, InstructorId = 1 },
                new Course { Id = 11, Name = "Python for Data Science", Description = "Learn Python and use it for data analysis and visualization.", Price = 65.0m, Rate = 5, ImageFile = "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", DurationInHours = 30, Level = "Advanced", LectureCount = 20, StartDate = new DateTime(2025, 9, 1), EndDate = new DateTime(2025, 9, 30), CategoryId = 3, InstructorId = 3 },
                new Course { Id = 12, Name = "CSS & Tailwind", Description = "Master modern CSS and Tailwind for responsive design.", Price = 35.0m, Rate = 4, ImageFile = "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", DurationInHours = 12, Level = "Beginner", LectureCount = 10, StartDate = new DateTime(2025, 9, 5), EndDate = new DateTime(2025, 9, 20), CategoryId = 2, InstructorId = 2 },
                new Course { Id = 13, Name = "Vue.js Fundamentals", Description = "Learn Vue.js from scratch and build interactive web apps.", Price = 50.0m, Rate = 4, ImageFile = "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", DurationInHours = 20, Level = "Beginner", LectureCount = 15, StartDate = new DateTime(2025, 10, 1), EndDate = new DateTime(2025, 10, 21), CategoryId = 1, InstructorId = 4 },
                new Course { Id = 14, Name = "Django Web Development", Description = "Build robust web applications using Django framework.", Price = 70.0m, Rate = 5, ImageFile = "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", DurationInHours = 35, Level = "Advanced", LectureCount = 22, StartDate = new DateTime(2025, 10, 5), EndDate = new DateTime(2025, 11, 15), CategoryId = 1, InstructorId = 1 },
                new Course { Id = 15, Name = "Photoshop Masterclass", Description = "Learn professional photo editing and manipulation in Photoshop.", Price = 40.0m, Rate = 4, ImageFile = "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", DurationInHours = 18, Level = "Intermediate", LectureCount = 14, StartDate = new DateTime(2025, 11, 1), EndDate = new DateTime(2025, 11, 20), CategoryId = 2, InstructorId = 3 }
            );
        }


        // ---------------- Relations ----------------
        public static void SeedRelations(ModelBuilder builder)
        {
            builder.Entity<CourseStudent>().HasData(
                new CourseStudent { StudentId = "3fa85f64-5717-4562-b3fc-2c963f66afa6", CourseId = 1 },
                new CourseStudent { StudentId = "4fa85f64-5717-4562-b3fc-2c963f66afa7", CourseId = 2 }
            );

            builder.Entity<InstructorStudent>().HasData(
                new InstructorStudent { StudentId = "3fa85f64-5717-4562-b3fc-2c963f66afa6", InstructorId = 1 },
                new InstructorStudent { StudentId = "4fa85f64-5717-4562-b3fc-2c963f66afa7", InstructorId = 2 }
            );
        }

        // ---------------- Call All ----------------
        public static void SeedAll(ModelBuilder builder)
        {
            SeedRoles(builder);
            SeedUsers(builder);
            SeedCategories(builder);
            SeedInstructors(builder);
            SeedCourses(builder);
            SeedRelations(builder);
        }
    }
}
