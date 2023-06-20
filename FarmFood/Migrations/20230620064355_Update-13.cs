using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmFood.Migrations
{
    /// <inheritdoc />
    public partial class Update13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sellerEmailPage",
                table: "Product",
                newName: "sellerEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sellerEmail",
                table: "Product",
                newName: "sellerEmailPage");
        }
    }
}
