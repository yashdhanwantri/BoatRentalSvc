using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoatRentalSvc.Migrations
{
    public partial class BoatRentalRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Boats",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Boats");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Boats",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boats",
                table: "Boats",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BoatRentals",
                columns: table => new
                {
                    RentalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    BoatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatRentals", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_BoatRentals_Boats_BoatId",
                        column: x => x.BoatId,
                        principalTable: "Boats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatRentals_BoatId",
                table: "BoatRentals",
                column: "BoatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatRentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boats",
                table: "Boats");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Boats");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Boats",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boats",
                table: "Boats",
                column: "Number");
        }
    }
}
