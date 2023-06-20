using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmFood.Migrations
{
    /// <inheritdoc />
    public partial class ProductUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServerID",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "SellerEmailPage",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerEmailPage",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "ServerID",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
