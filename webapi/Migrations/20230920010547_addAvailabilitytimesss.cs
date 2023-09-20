using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class addAvailabilitytimesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fa34e84-564f-4f32-b862-76c1ff19ae39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40a6a0b2-175a-44d9-9024-3caa8f53c580");

            migrationBuilder.DropColumn(
                name: "SatrtTime",
                table: "UserAvailabilities");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "UserAvailabilities",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "UserAvailabilities",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "828811e4-44fc-43dd-ae4b-a25d73e5ab82", null, "User", "USER" },
                    { "d208d50b-d138-4fea-8d2e-817b579b45cc", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828811e4-44fc-43dd-ae4b-a25d73e5ab82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d208d50b-d138-4fea-8d2e-817b579b45cc");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "UserAvailabilities");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "UserAvailabilities",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<DateTime>(
                name: "SatrtTime",
                table: "UserAvailabilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fa34e84-564f-4f32-b862-76c1ff19ae39", null, "Admin", "ADMIN" },
                    { "40a6a0b2-175a-44d9-9024-3caa8f53c580", null, "User", "USER" }
                });
        }
    }
}
