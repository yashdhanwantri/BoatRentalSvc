using Microsoft.EntityFrameworkCore.Migrations;

namespace BoatRentalSvc.Migrations
{
    public partial class PropertyUpdateImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Boats");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Boats",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Boats");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Boats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
