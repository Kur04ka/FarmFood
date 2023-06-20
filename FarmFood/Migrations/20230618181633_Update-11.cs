using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace FarmFood.Migrations
{
    /// <inheritdoc />
    public partial class Update11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryOfResidence",
                table: "User");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "User");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateOfRegistration",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateOfRegistration",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "CountryOfResidence",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userID",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
