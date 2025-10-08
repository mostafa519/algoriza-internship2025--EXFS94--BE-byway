using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByWay.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class final_updates1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "370b1134-7975-4edd-889c-b7524c09869b", "AQAAAAIAAYagAAAAEJoWffAD1RcE+VJ6kVW46H2hvCmA6kOLGwei1txpCoMSRS8+Chu2UWeq5hhw11yDBg==", "18856a76-8c2b-42f0-8174-8f46aa086f29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fa85f64-5717-4562-b3fc-2c963f66afa7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a692aacc-b922-45f9-a98c-f17d84d3dada", "AQAAAAIAAYagAAAAELqSUid1RR/CdixnHuhJO1KnOEkUZOoBXnYr+p+3Io8i93B28wn+xmnP/7Wrp2Bqcg==", "2f16e235-ec69-4ea2-9e11-9c3b1d45cdb3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2c3d4e5-f6a7-8901-bcde-234567890abc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "380c0ca4-3c56-4b4f-b691-95842c8643cc", "AQAAAAIAAYagAAAAEPJNVfA40YzN8LHc+kZS+67cumkU2SyfmW8faMPEUwnfzX+XRAiJHrHiqeySPNUIIg==", "2bf9ef23-7d24-4b1b-b6a7-fec7a2b7a91a" });

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, "3fa85f64-5717-4562-b3fc-2c963f66afa6" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 8, 19, 8, 46, 136, DateTimeKind.Local).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, "4fa85f64-5717-4562-b3fc-2c963f66afa7" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 8, 19, 8, 46, 139, DateTimeKind.Local).AddTicks(4185));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a13f560d-f685-456a-9a51-24393fa4c813", "AQAAAAIAAYagAAAAEAfgguB0mLiG0UwWfn8xyzZOtu53XnXEy+Au8U+wgMhRXVNDRBlU7rRVcU9T57l/Gg==", "1a0a9591-dbe8-486b-8006-ddab5fd7e654" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fa85f64-5717-4562-b3fc-2c963f66afa7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1000fffd-6fcc-415e-9a92-37c02eaf4191", "AQAAAAIAAYagAAAAEOUNLlElG+U4UqR0jYEZM5EZhFg4Sx4JLZgyUag9nxZYCoMY/xvoqOlMoeealFRaGQ==", "661c33ef-a637-41b9-a28b-7abe607dc4e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2c3d4e5-f6a7-8901-bcde-234567890abc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce59166e-4a4e-4a2e-9794-ddac61e6ac90", "AQAAAAIAAYagAAAAELw4rwXdiTrS9CEiufxKC/yklU/E1yz3yZnZz9Ui3DckLYSJpT6ZephsTHxhsRrXig==", "fb668d6d-9616-42b3-baf3-603aa8c163f5" });

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, "3fa85f64-5717-4562-b3fc-2c963f66afa6" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 8, 18, 57, 56, 122, DateTimeKind.Local).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, "4fa85f64-5717-4562-b3fc-2c963f66afa7" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 8, 18, 57, 56, 128, DateTimeKind.Local).AddTicks(7010));
        }
    }
}
