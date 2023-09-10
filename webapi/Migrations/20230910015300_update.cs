using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d3f6dfe-1d8b-4116-8ae9-aac47462e72f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bb8d4d7-91d1-420c-ab9b-14ac8634d722");

            migrationBuilder.DropColumn(
                name: "HostId",
                table: "BookedEvents");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3fe8fb28-ae44-42ec-8b8e-2ff3112e7371", null, "User", "USER" },
                    { "7b0b4c19-3c36-409d-8238-53be2a04e714", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fe8fb28-ae44-42ec-8b8e-2ff3112e7371");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b0b4c19-3c36-409d-8238-53be2a04e714");

            migrationBuilder.AddColumn<string>(
                name: "HostId",
                table: "BookedEvents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d3f6dfe-1d8b-4116-8ae9-aac47462e72f", null, "Admin", "ADMIN" },
                    { "9bb8d4d7-91d1-420c-ab9b-14ac8634d722", null, "User", "USER" }
                });
        }
    }
}
