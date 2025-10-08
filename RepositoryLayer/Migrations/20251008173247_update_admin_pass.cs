using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByWay.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class update_admin_pass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f593332-26e3-4fd8-b8ee-2c3ee402d950", "AQAAAAIAAYagAAAAEAY9bo4d276pfhIIAzLmIwnyU2iONQCOc1ntC3kSiDGTDL/BWrhQfPpMukPrQnH/OQ==", "2900e17d-cdc5-40d1-98d1-fbfd99764cd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fa85f64-5717-4562-b3fc-2c963f66afa7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a49a106-acbd-4d5e-813e-c6ad080b9898", "AQAAAAIAAYagAAAAEIpU8N3uITE8X8wi9y5cy/ihjjY5Vbw+02zsNbJiGSG53mH7pYvhW7vgWqu/PKrwLg==", "bbe69cfd-44f0-4dcf-ae61-befa9cd482ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2c3d4e5-f6a7-8901-bcde-234567890abc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "839ae7e5-0030-4251-9696-5e5b81c1a9bb", "AQAAAAIAAYagAAAAENg0LaOm+w0cXJSC5li5kbPHj7PprrlHiD5fM5niGTah6rkVLD8XM820ghwuhLc/UA==", "f7229c54-8b55-40f9-9c2a-064f0a1468b7" });

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, "3fa85f64-5717-4562-b3fc-2c963f66afa6" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 8, 20, 32, 41, 900, DateTimeKind.Local).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, "4fa85f64-5717-4562-b3fc-2c963f66afa7" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 8, 20, 32, 41, 904, DateTimeKind.Local).AddTicks(7182));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
