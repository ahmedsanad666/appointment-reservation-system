using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class addAvailabilitytimesssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "325000c4-b31f-4e3c-a2fe-6054fdb5ce47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b82fb408-43d3-4169-af90-0fdea73b9df9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34ee5350-78d4-4e5d-989d-41d6ed4deccc", null, "Admin", "ADMIN" },
                    { "5defd20c-7c25-44b7-aef1-b691a1d051b6", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34ee5350-78d4-4e5d-989d-41d6ed4deccc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5defd20c-7c25-44b7-aef1-b691a1d051b6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "325000c4-b31f-4e3c-a2fe-6054fdb5ce47", null, "User", "USER" },
                    { "b82fb408-43d3-4169-af90-0fdea73b9df9", null, "Admin", "ADMIN" }
                });
        }
    }
}
