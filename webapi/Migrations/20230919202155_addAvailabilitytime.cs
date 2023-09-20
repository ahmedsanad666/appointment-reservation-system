using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class addAvailabilitytime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fe8fb28-ae44-42ec-8b8e-2ff3112e7371");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b0b4c19-3c36-409d-8238-53be2a04e714");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d96e6e5-215c-4dbb-bc09-5e9448d21d06", null, "User", "USER" },
                    { "b87ccb66-8aa6-4449-a064-b9ceb46b5902", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d96e6e5-215c-4dbb-bc09-5e9448d21d06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b87ccb66-8aa6-4449-a064-b9ceb46b5902");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fe8fb28-ae44-42ec-8b8e-2ff3112e7371", null, "User", "USER" },
                    { "7b0b4c19-3c36-409d-8238-53be2a04e714", null, "Admin", "ADMIN" }
                });
        }
    }
}
