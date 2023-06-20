using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmFood.Migrations
{
    /// <inheritdoc />
    public partial class ShopCartItemUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "ShopCartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "ShopCartItem");
        }
    }
}
