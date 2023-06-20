using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmFood.Migrations
{
    /// <inheritdoc />
    public partial class UserUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "check",
                table: "ShopCartItem");

            migrationBuilder.DropColumn(
                name: "check",
                table: "ShopCart");

            migrationBuilder.AddColumn<string>(
                name: "CityOfResidence",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telegram",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VKontakte",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhatsApp",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityOfResidence",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Telegram",
                table: "User");

            migrationBuilder.DropColumn(
                name: "VKontakte",
                table: "User");

            migrationBuilder.DropColumn(
                name: "WhatsApp",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "check",
                table: "ShopCartItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "check",
                table: "ShopCart",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
