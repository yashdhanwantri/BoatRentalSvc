using Microsoft.EntityFrameworkCore.Migrations;

namespace BoatRentalSvc.Migrations
{
    public partial class BoatNameDataTypeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BoatName",
                table: "Boats",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BoatName",
                table: "Boats",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
