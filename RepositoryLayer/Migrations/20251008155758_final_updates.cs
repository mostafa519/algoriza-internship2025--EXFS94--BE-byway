using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByWay.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class final_updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4fd534c-08d9-4d35-b7e2-61b3e8eeb9d5", "AQAAAAIAAYagAAAAEGIge1LYOQnQs9nRbawd3Un1pZofjKhgAPxCe5WBtJcMl3MoWt/QfCEA0YXI4YiBVw==", "b91cf6cf-36d9-426f-921e-2f75b0fecdc9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fa85f64-5717-4562-b3fc-2c963f66afa7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac8b8c21-fcfe-4da6-8e87-db2e90c38801", "AQAAAAIAAYagAAAAEKQHgzedCWSr5zfA/iFDVhNH7RJpTwkvKbu57ma0azTRvXLS3l55j0XQRngA9OHw6A==", "ac3ca2d1-02fd-4dae-8eb0-2c5a743d3c20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2c3d4e5-f6a7-8901-bcde-234567890abc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ef33ad8-a564-4504-b951-8f703242e7bc", "AQAAAAIAAYagAAAAEK2If9BwYWZKKN5YkrJYXJe32hyBB+YJ4zearvlxiqUQ1H90bF2gM0fElhCk1wVOhg==", "527572eb-1c68-4c0a-aee1-7bed85def6b6" });

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, "3fa85f64-5717-4562-b3fc-2c963f66afa6" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 8, 18, 38, 37, 104, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "CourseStudents",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, "4fa85f64-5717-4562-b3fc-2c963f66afa7" },
                column: "EnrollmentDate",
                value: new DateTime(2025, 10, 8, 18, 38, 37, 107, DateTimeKind.Local).AddTicks(2708));
        }
    }
}
