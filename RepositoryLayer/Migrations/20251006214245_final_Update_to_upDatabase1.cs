using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByWay.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class final_Update_to_upDatabase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a79f9372-b8c7-46e3-858a-e38686730eff", "AQAAAAIAAYagAAAAEKS9kEfQanuo2cbpcxklVUF8Blo7M58EC+/NJmUyG6W6X8kfl6VvQkp4qiwro9UTRQ==", "3509ac86-c502-4c3c-9372-82c08db2b495" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fa85f64-5717-4562-b3fc-2c963f66afa7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95f7f95e-06dc-4ad8-a61f-c0448bd0d750", "AQAAAAIAAYagAAAAEPkXZVi91B3LYKz9oN++wrP5ndhBVIXd80xHuUPpm7EIxfTr3zqj2IWLP3LWQnHrnA==", "40a3c981-d461-4c7e-98e7-1f125d1b413c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2c3d4e5-f6a7-8901-bcde-234567890abc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54ce9d59-46a8-4e14-ad74-30b1b38e8aff", "AQAAAAIAAYagAAAAEFLUTYF4kDD2eSrbM8ovt1weyNegbqEyG7Gw81YWm77ks7DIclxAFq8sILBKzcs4+g==", "bea61f49-2f3a-4820-aa97-ae8e6708af8d" });

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, "3fa85f64-5717-4562-b3fc-2c963f66afa6" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 7, 0, 42, 43, 540, DateTimeKind.Local).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, "4fa85f64-5717-4562-b3fc-2c963f66afa7" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 7, 0, 42, 43, 553, DateTimeKind.Local).AddTicks(5765));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe764a5d-7979-4c2b-803c-94d9c90d79be", "AQAAAAIAAYagAAAAEOmc5UxYCnB7QKe+33bw6IN9mH6hMyy9rNXpd/5wFKDlYRiH3LOVWhLBRYce9kT6IQ==", "270f13ed-3b00-4873-83f9-dbd471ea579e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fa85f64-5717-4562-b3fc-2c963f66afa7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff93ed5d-2b6e-4892-82e4-63f4455ef15c", "AQAAAAIAAYagAAAAEKP5WRkALC4DVastNV/wRIfI93VRKF33wVLi7DjDiboTmLz0ICtndMrHXx5DdDrTRQ==", "4d34e4ad-3453-466a-91f4-41a6053d4e3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2c3d4e5-f6a7-8901-bcde-234567890abc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35fd0f8e-d271-45e6-94c2-42cdc909db6e", "AQAAAAIAAYagAAAAENbVm7dLYguThNFQxclXZHg0HsbM98GdLs6GB++oMyByFJXpnJiUxaxpD35D6KWplA==", "0041c880-cc88-4c28-87c4-d3762d0441bd" });

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, "3fa85f64-5717-4562-b3fc-2c963f66afa6" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 6, 23, 43, 16, 155, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, "4fa85f64-5717-4562-b3fc-2c963f66afa7" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 6, 23, 43, 16, 159, DateTimeKind.Local).AddTicks(8537));
        }
    }
}
