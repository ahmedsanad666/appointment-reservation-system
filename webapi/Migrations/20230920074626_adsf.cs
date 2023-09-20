using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class adsf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "9b13ba33-e6bf-4ee6-9ad1-8b0a5007d27f", null, "Admin", "ADMIN" },
                    { "ab1c020b-551b-4269-85d4-00e659807c6c", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b13ba33-e6bf-4ee6-9ad1-8b0a5007d27f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab1c020b-551b-4269-85d4-00e659807c6c");

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
    }
}
