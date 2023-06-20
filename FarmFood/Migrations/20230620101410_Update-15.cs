using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmFood.Migrations
{
    /// <inheritdoc />
    public partial class Update15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "countryOfOrigin",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "countryOfOrigin",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
