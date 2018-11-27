using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleMiddleware.Migrations
{
    public partial class TambahFieldAddressTableRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Restaurant",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Restaurant");
        }
    }
}
