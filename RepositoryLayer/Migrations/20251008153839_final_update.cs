using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ByWay.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class final_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentProfiles",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CardName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVC = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProfiles", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_StudentProfiles_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryStudents",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryStudents", x => new { x.CategoryId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_CategoryStudents_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryStudents_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    ImageFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationInHours = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LectureCount = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorCategories",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorCategories", x => new { x.InstructorId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_InstructorCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorCategories_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorStudents",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorStudents", x => new { x.InstructorId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_InstructorStudents_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorStudents_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudents",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudents", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_CourseStudents_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudents_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteCourseEnrollments",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteCourseEnrollments", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_FavoriteCourseEnrollments_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteCourseEnrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", null, "Admin", "ADMIN" },
                    { "22222222-2222-2222-2222-222222222222", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccountType", "ConcurrencyStamp", "Email", "EmailConfirmed", "EnrollmentDate", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3fa85f64-5717-4562-b3fc-2c963f66afa6", 0, 1, "b4fd534c-08d9-4d35-b7e2-61b3e8eeb9d5", "mustafa.ali@example.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mustafa", "Ali", false, null, "MUSTAFA.ALI@EXAMPLE.COM", "MUSTAFA", "AQAAAAIAAYagAAAAEGIge1LYOQnQs9nRbawd3Un1pZofjKhgAPxCe5WBtJcMl3MoWt/QfCEA0YXI4YiBVw==", null, false, "b91cf6cf-36d9-426f-921e-2f75b0fecdc9", false, "mustafa" },
                    { "4fa85f64-5717-4562-b3fc-2c963f66afa7", 0, 1, "ac8b8c21-fcfe-4da6-8e87-db2e90c38801", "john.doe@example.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEKQHgzedCWSr5zfA/iFDVhNH7RJpTwkvKbu57ma0azTRvXLS3l55j0XQRngA9OHw6A==", null, false, "ac3ca2d1-02fd-4dae-8eb0-2c5a743d3c20", false, "johndoe" },
                    { "b2c3d4e5-f6a7-8901-bcde-234567890abc", 0, 0, "6ef33ad8-a564-4504-b951-8f703242e7bc", "admin@byway.com", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Admin", false, null, "ADMIN@BYWAY.COM", "ADMIN@BYWAY.COM", "AQAAAAIAAYagAAAAEK2If9BwYWZKKN5YkrJYXJe32hyBB+YJ4zearvlxiqUQ1H90bF2gM0fElhCk1wVOhg==", null, false, "527572eb-1c68-4c0a-aee1-7bed85def6b6", false, "admin@byway.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "fa-laptop-code", "Development" },
                    { 2, "fa-paint-brush", "Design" },
                    { 3, "fa-book", "Education" },
                    { 4, "fa-music", "Music" },
                    { 5, "fa-camera", "Photography" },
                    { 6, "fa-dumbbell", "Fitness" },
                    { 7, "fa-globe", "Travel" },
                    { 8, "fa-heart", "Health" },
                    { 9, "fa-film", "Movies" },
                    { 10, "fa-code", "Programming" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Description", "ImageFile", "JobTitle", "Name", "Rate" },
                values: new object[,]
                {
                    { 1, "Specialist in React and modern JavaScript frameworks.", "https://tse4.mm.bing.net/th/id/OIP.nkt3lTa7B747RqrCP8mdQAHaHa?rs=1&pid=ImgDetMain&o=7&rm=3", "Frontend Developer", "Ali Hassan", 4.7999999999999998 },
                    { 2, "Expert in both frontend and backend technologies.", "https://tse4.mm.bing.net/th/id/OIP.nkt3lTa7B747RqrCP8mdQAHaHa?rs=1&pid=ImgDetMain&o=7&rm=3", "Full-Stack Developer", "Mustafa Ali", 4.9000000000000004 },
                    { 3, "Expert in APIs, microservices, and .NET 8.", "https://tse4.mm.bing.net/th/id/OIP.nkt3lTa7B747RqrCP8mdQAHaHa?rs=1&pid=ImgDetMain&o=7&rm=3", "Backend Developer", "Ahmed Ali", 4.7000000000000002 },
                    { 4, "Designs stunning and user-friendly interfaces.", "https://img.freepik.com/premium-vector/teacher-cartoon-illustration-with-sign_1120558-20344.jpg?w=2000", "UI/UX Designer", "Eslam Mohamed", 4.5999999999999996 },
                    { 5, "Specialist in Python, Machine Learning, and AI.", "https://img.freepik.com/premium-vector/teacher-cartoon-illustration-with-sign_1120558-20344.jpg?w=2000", "Data Scientist", "Sara Khalid", 4.7999999999999998 },
                    { 6, "Expert in CI/CD, Docker, and Kubernetes.", "https://img.freepik.com/premium-vector/teacher-cartoon-illustration-with-sign_1120558-20344.jpg?w=2000", "DevOps Engineer", "Hassan Omar", 4.7000000000000002 },
                    { 7, "Builds iOS and Android apps with Flutter and React Native.", "https://s3.amazonaws.com/coursesity-blog/2023/12/Mobile_Development_Courses.jpg", "Mobile Developer", "Laila Samir", 4.5 },
                    { 8, "Focuses on Python, Django, and automation.", "https://img.freepik.com/premium-vector/teacher-cartoon-illustration-with-sign_1120558-20344.jpg?w=2000", "Python Developer", "Omar Adel", 4.5999999999999996 },
                    { 9, "Creates stunning visuals and brand identities.", "https://img.freepik.com/premium-vector/teacher-presenting-lesson-front-green-chalkboard_126712-18933.jpg?w=2000", "Graphic Designer", "Mona Fathi", 4.7000000000000002 },
                    { 10, "Specialist in Java, Spring Boot, and backend architectures.", "https://img.freepik.com/premium-vector/teacher-presenting-lesson-front-green-chalkboard_126712-18933.jpg?w=2000", "Java Developer", "Khaled Youssef", 4.7999999999999998 },
                    { 11, "Optimizes websites for search engines and traffic growth.", "https://img.freepik.com/premium-vector/teacher-presenting-lesson-front-green-chalkboard_126712-18933.jpg?w=2000", "SEO Expert", "Fatma Hany", 4.5 },
                    { 12, "Expert in AWS, Azure, and scalable cloud solutions.", "https://img.freepik.com/premium-vector/teacher-presenting-lesson-front-green-chalkboard_126712-18933.jpg?w=2000", "Cloud Architect", "Youssef Samir", 4.7000000000000002 },
                    { 13, "Focus on network security and ethical hacking.", "https://img.freepik.com/premium-vector/teacher-presenting-lesson-front-green-chalkboard_126712-18933.jpg?w=2000", "Cybersecurity Specialist", "Nada Ahmed", 4.5999999999999996 },
                    { 14, "Builds AI models and intelligent systems.", "https://img.freepik.com/premium-vector/teacher-presenting-lesson-front-green-chalkboard_126712-18933.jpg?w=2000", "AI Engineer", "Mahmoud Tarek", 4.9000000000000004 },
                    { 15, "Expert in Premiere Pro, After Effects, and video production.", "https://tse4.mm.bing.net/th/id/OIP.mCRDsfv9LcGpqRuglQ7ZxQHaFj?w=626&h=470&rs=1&pid=ImgDetMain&o=7&rm=3", "Video Editor", "Salma Fawzy", 4.5 },
                    { 16, "Experienced in building scalable web applications using ASP.NET Core and React.", "https://tse4.mm.bing.net/th/id/OIP.mCRDsfv9LcGpqRuglQ7ZxQHaFj?w=626&h=470&rs=1&pid=ImgDetMain&o=7&rm=3", "Senior Full Stack Developer", "John Doe", 4.7999999999999998 },
                    { 17, "Specialist in UI/UX optimization for modern apps.", "https://tse4.mm.bing.net/th/id/OIP.mCRDsfv9LcGpqRuglQ7ZxQHaFj?w=626&h=470&rs=1&pid=ImgDetMain&o=7&rm=3", "UI/UX Designer", "Jane Smith", 4.5999999999999996 },
                    { 18, "Expert in APIs, microservices, and .NET 8.", "https://tse4.mm.bing.net/th/id/OIP.mCRDsfv9LcGpqRuglQ7ZxQHaFj?w=626&h=470&rs=1&pid=ImgDetMain&o=7&rm=3", "Backend Developer", "Ahmed Ali", 4.7000000000000002 },
                    { 19, "Focused on crafting responsive React apps.", "https://tse4.mm.bing.net/th/id/OIP.mCRDsfv9LcGpqRuglQ7ZxQHaFj?w=626&h=470&rs=1&pid=ImgDetMain&o=7&rm=3", "Frontend Developer", "Sara Johnson", 4.5 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "22222222-2222-2222-2222-222222222222", "3fa85f64-5717-4562-b3fc-2c963f66afa6" },
                    { "22222222-2222-2222-2222-222222222222", "4fa85f64-5717-4562-b3fc-2c963f66afa7" },
                    { "11111111-1111-1111-1111-111111111111", "b2c3d4e5-f6a7-8901-bcde-234567890abc" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Description", "DurationInHours", "EndDate", "ImageFile", "InstructorId", "LectureCount", "Level", "Name", "Price", "Rate", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, "Learn full stack development with React & .NET.", 60, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://tse3.mm.bing.net/th/id/OIP.OlilRMMjyjCRGtmJmgUZ5wHaEK", 1, 45, "Intermediate", "Full Stack Web Development", 199.99m, 4.7999999999999998, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "Master the fundamentals of UI/UX design.", 40, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.excelptp.com/wp-content/uploads/2023/01/ui-ux-banner-img2.jpg", 2, 30, "Beginner", "UI/UX Design Principles", 149.99m, 4.5999999999999996, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, "Design stunning and user-friendly interfaces.", 15, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", 2, 12, "Intermediate", "UI/UX Design", 39.0m, 3.0, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, "Become a full-stack developer using modern technologies.", 40, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", 1, 25, "Advanced", "Full-Stack Development", 79.0m, 5.0, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, "Learn the basics of React and build dynamic web apps.", 20, new DateTime(2025, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", 2, 15, "Beginner", "React for Beginners", 49.0m, 4.0, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, "Master JavaScript with advanced concepts and best practices.", 25, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", 1, 18, "Advanced", "Advanced JavaScript", 59.0m, 5.0, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, "Design stunning and user-friendly interfaces.", 15, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", 3, 12, "Intermediate", "UI/UX Design", 39.0m, 3.0, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, "Become a full-stack developer using modern technologies.", 40, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", 4, 25, "Advanced", "Full-Stack Development", 79.0m, 5.0, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, "Get started with Angular and build single-page applications.", 18, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", 2, 14, "Beginner", "Angular Basics", 45.0m, 4.0, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, "Learn backend development with Node.js and Express.", 22, new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", 1, 17, "Intermediate", "Node.js Essentials", 55.0m, 5.0, new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 3, "Learn Python and use it for data analysis and visualization.", 30, new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", 3, 20, "Advanced", "Python for Data Science", 65.0m, 5.0, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 2, "Master modern CSS and Tailwind for responsive design.", 12, new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", 2, 10, "Beginner", "CSS & Tailwind", 35.0m, 4.0, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 1, "Learn Vue.js from scratch and build interactive web apps.", 20, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", 4, 15, "Beginner", "Vue.js Fundamentals", 50.0m, 4.0, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 1, "Build robust web applications using Django framework.", 35, new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", 1, 22, "Advanced", "Django Web Development", 70.0m, 5.0, new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 2, "Learn professional photo editing and manipulation in Photoshop.", 18, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/man-sits-desk-reading-book_704913-28714.jpg", 3, 14, "Intermediate", "Photoshop Masterclass", 40.0m, 4.0, new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "InstructorStudents",
                columns: new[] { "InstructorId", "StudentId", "Id" },
                values: new object[,]
                {
                    { 1, "3fa85f64-5717-4562-b3fc-2c963f66afa6", 0 },
                    { 2, "4fa85f64-5717-4562-b3fc-2c963f66afa7", 0 }
                });

            migrationBuilder.InsertData(
                table: "CourseStudents",
                columns: new[] { "CourseId", "StudentId", "EnrollmentDate", "Id" },
                values: new object[,]
                {
                    { 1, "3fa85f64-5717-4562-b3fc-2c963f66afa6", new DateTime(2025, 10, 8, 18, 38, 37, 104, DateTimeKind.Local).AddTicks(5872), 0 },
                    { 2, "4fa85f64-5717-4562-b3fc-2c963f66afa7", new DateTime(2025, 10, 8, 18, 38, 37, 107, DateTimeKind.Local).AddTicks(2708), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryStudents_StudentId",
                table: "CategoryStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_StudentId",
                table: "CourseStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCourseEnrollments_CourseId",
                table: "FavoriteCourseEnrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCategories_CategoryId",
                table: "InstructorCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorStudents_StudentId",
                table: "InstructorStudents",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CategoryStudents");

            migrationBuilder.DropTable(
                name: "CourseStudents");

            migrationBuilder.DropTable(
                name: "FavoriteCourseEnrollments");

            migrationBuilder.DropTable(
                name: "InstructorCategories");

            migrationBuilder.DropTable(
                name: "InstructorStudents");

            migrationBuilder.DropTable(
                name: "StudentProfiles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
