using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmFood.Migrations
{
    /// <inheritdoc />
    public partial class ShopCartItemUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "ShopCartItem");

            migrationBuilder.RenameColumn(
                name: "SellerEmailPage",
                table: "Product",
                newName: "sellerEmailPage");

            migrationBuilder.AddColumn<string>(
                name: "quantityInsideCart",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantityInsideCart",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "sellerEmailPage",
                table: "Product",
                newName: "SellerEmailPage");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "ShopCartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
