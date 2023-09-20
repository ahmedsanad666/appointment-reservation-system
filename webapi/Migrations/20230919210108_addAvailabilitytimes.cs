using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class addAvailabilitytimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d96e6e5-215c-4dbb-bc09-5e9448d21d06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b87ccb66-8aa6-4449-a064-b9ceb46b5902");

            migrationBuilder.CreateTable(
                name: "UserAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatrtTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAvailabilities_AspNetUsers_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fa34e84-564f-4f32-b862-76c1ff19ae39", null, "Admin", "ADMIN" },
                    { "40a6a0b2-175a-44d9-9024-3caa8f53c580", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAvailabilities_ApiUserId",
                table: "UserAvailabilities",
                column: "ApiUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAvailabilities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fa34e84-564f-4f32-b862-76c1ff19ae39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40a6a0b2-175a-44d9-9024-3caa8f53c580");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d96e6e5-215c-4dbb-bc09-5e9448d21d06", null, "User", "USER" },
                    { "b87ccb66-8aa6-4449-a064-b9ceb46b5902", null, "Admin", "ADMIN" }
                });
        }
    }
}
