using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class addAvailabilitytimesssssd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34ee5350-78d4-4e5d-989d-41d6ed4deccc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5defd20c-7c25-44b7-aef1-b691a1d051b6");

            migrationBuilder.AddColumn<string>(
                name: "DaysString",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "092c353e-092c-4034-b353-4996e3d0fe3c", null, "User", "USER" },
                    { "662ac8ac-5a87-442a-a6fd-544a14214dae", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "092c353e-092c-4034-b353-4996e3d0fe3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "662ac8ac-5a87-442a-a6fd-544a14214dae");

            migrationBuilder.DropColumn(
                name: "DaysString",
                table: "Appointments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34ee5350-78d4-4e5d-989d-41d6ed4deccc", null, "Admin", "ADMIN" },
                    { "5defd20c-7c25-44b7-aef1-b691a1d051b6", null, "User", "USER" }
                });
        }
    }
}
