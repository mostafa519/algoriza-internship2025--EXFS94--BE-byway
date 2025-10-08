using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByWay.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class final_updates_final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6280cba-88e0-45e6-9c57-0f77ba69d5e8", "AQAAAAIAAYagAAAAEOgBD2mOkmTZGa7IzTV8p/PdPmQLjsubCooN8Dkxzzq9Ve3b1P5FCFeEryhvs5gJBA==", "fe9f3047-2c03-40aa-a834-53f051dee192" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fa85f64-5717-4562-b3fc-2c963f66afa7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7729ac8d-c3ed-459b-93ac-44e6c1c03854", "AQAAAAIAAYagAAAAENWG2DwTEX6x5XnJSw9JaCYPgyydBygGieYsuq9z/XpVYWjq7hZcpD+TxRXZcbJZSw==", "d84d7d9d-eb19-4611-9482-449181198bf4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2c3d4e5-f6a7-8901-bcde-234567890abc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3667b06d-075f-4a36-bdb5-076185a9fca0", "AQAAAAIAAYagAAAAEFX3Ip8FPGY6/zbPtmRJW1eOa2udVxQfZyPDlnVk9HMV34ZUJhrKOX2VSjCoPlxGFw==", "0de9db8d-f2fc-45f6-ab18-abb8043e9916" });

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, "3fa85f64-5717-4562-b3fc-2c963f66afa6" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 8, 19, 58, 14, 760, DateTimeKind.Local).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, "4fa85f64-5717-4562-b3fc-2c963f66afa7" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 8, 19, 58, 14, 762, DateTimeKind.Local).AddTicks(6740));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f035dc3a-6e0a-45b0-9825-790407f64ef3", "AQAAAAIAAYagAAAAEJCsvqJm9vvR4GfghxjWloiZcKMsffvzzQ1POGFdInCDAaihkd4hgRDf2aBCIuuTOg==", "9f6bc44f-af45-4e63-824e-902dbbd91e9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fa85f64-5717-4562-b3fc-2c963f66afa7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40c93f53-d00f-4d68-879e-df363d22a84d", "AQAAAAIAAYagAAAAEJfG3/l0uxzWL9ICuPEahoVyTX/HB7iGQ4soTyWqNbPMSHYox/QpB25f7lViTvdK+Q==", "ea700634-f0bf-42f6-a9e5-0c4048738776" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2c3d4e5-f6a7-8901-bcde-234567890abc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cf51b34-f68c-4f82-ab49-abf2854e8b9d", "AQAAAAIAAYagAAAAEAj99+DG8zkMSMDN8DAvEriP5APyJP2GwmsT3Cqfmz6JNqdttjZCk2cVJMwi3uVF0w==", "a52ceab3-8583-44d1-9c01-58bcae93ee3e" });

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, "3fa85f64-5717-4562-b3fc-2c963f66afa6" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 8, 19, 42, 5, 591, DateTimeKind.Local).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, "4fa85f64-5717-4562-b3fc-2c963f66afa7" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 8, 19, 42, 5, 594, DateTimeKind.Local).AddTicks(665));
        }
    }
}
