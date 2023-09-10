using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class editmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8129c30a-2312-42b7-a04f-ddf4efc336c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adca0815-0582-47c8-8e71-d9e388eaa317");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d3f6dfe-1d8b-4116-8ae9-aac47462e72f", null, "Admin", "ADMIN" },
                    { "9bb8d4d7-91d1-420c-ab9b-14ac8634d722", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d3f6dfe-1d8b-4116-8ae9-aac47462e72f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bb8d4d7-91d1-420c-ab9b-14ac8634d722");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8129c30a-2312-42b7-a04f-ddf4efc336c4", null, "Admin", "ADMIN" },
                    { "adca0815-0582-47c8-8e71-d9e388eaa317", null, "User", "USER" }
                });
        }
    }
}
