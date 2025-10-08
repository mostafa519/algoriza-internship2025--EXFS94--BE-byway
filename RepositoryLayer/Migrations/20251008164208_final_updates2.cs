using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByWay.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class final_updates2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCourseEnrollments_AspNetUsers_StudentId",
                table: "FavoriteCourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfiles_AspNetUsers_StudentId",
                table: "StudentProfiles");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentProfiles",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "FavoriteCourseEnrollments",
                newName: "UserName");

            migrationBuilder.AlterColumn<int>(
                name: "CVC",
                table: "StudentProfiles",
                type: "int",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

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

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCourseEnrollments_AspNetUsers_UserName",
                table: "FavoriteCourseEnrollments",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfiles_AspNetUsers_UserName",
                table: "StudentProfiles",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteCourseEnrollments_AspNetUsers_UserName",
                table: "FavoriteCourseEnrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfiles_AspNetUsers_UserName",
                table: "StudentProfiles");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "StudentProfiles",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "FavoriteCourseEnrollments",
                newName: "StudentId");

            migrationBuilder.AlterColumn<string>(
                name: "CVC",
                table: "StudentProfiles",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 4);

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

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteCourseEnrollments_AspNetUsers_StudentId",
                table: "FavoriteCourseEnrollments",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfiles_AspNetUsers_StudentId",
                table: "StudentProfiles",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
