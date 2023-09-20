using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class adsfs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CustomId",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83a874d4-748f-41fc-9b5f-675b6781a9b5", null, "Admin", "ADMIN" },
                    { "ab3a2f71-0057-4abb-ae73-673e32debb12", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83a874d4-748f-41fc-9b5f-675b6781a9b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab3a2f71-0057-4abb-ae73-673e32debb12");

            migrationBuilder.DropColumn(
                name: "CustomId",
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
    }
}
