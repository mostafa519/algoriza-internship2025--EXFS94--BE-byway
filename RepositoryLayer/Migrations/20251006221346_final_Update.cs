using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByWay.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class final_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf614daa-6780-4b37-b925-6413c042a6f6", "AQAAAAIAAYagAAAAENTiACyll1y8nMvXRTOUqAo8niC98igwcr8yBgnnbI3m40t02P8BW0+sH2FYwkfqDg==", "3202e055-9d2a-4949-a8b7-11f5142cb76c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fa85f64-5717-4562-b3fc-2c963f66afa7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e955d49a-4221-4146-b0c3-71c9eb82ef01", "AQAAAAIAAYagAAAAEFaAmq9DcmHzJlHCkA+mUKdCzPP7U2KKduWHYf/pJd0DYwAilIqRhMoQaVnRJ5EsFA==", "36b531aa-f3ea-4582-8133-2d06ac7affc8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2c3d4e5-f6a7-8901-bcde-234567890abc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3d6a6c3-6c95-4014-8f6b-0e87affb3919", "AQAAAAIAAYagAAAAEI4XgCclMd3cmDBxxiagP7Tc1QqqnUD5VzTdgxECakaoTKNXUp8bxxHJFCaCnVpslQ==", "cd1a0e49-c257-4711-8af7-c7e5689a4b1c" });

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, "3fa85f64-5717-4562-b3fc-2c963f66afa6" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 7, 1, 13, 43, 545, DateTimeKind.Local).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, "4fa85f64-5717-4562-b3fc-2c963f66afa7" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 7, 1, 13, 43, 549, DateTimeKind.Local).AddTicks(6787));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
