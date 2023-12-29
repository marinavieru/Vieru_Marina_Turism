using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vieru_Marina_Turism.Migrations
{
    public partial class Flight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightID",
                table: "Holiday",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holiday_FlightID",
                table: "Holiday",
                column: "FlightID");

            migrationBuilder.AddForeignKey(
                name: "FK_Holiday_Flight_FlightID",
                table: "Holiday",
                column: "FlightID",
                principalTable: "Flight",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holiday_Flight_FlightID",
                table: "Holiday");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Holiday_FlightID",
                table: "Holiday");

            migrationBuilder.DropColumn(
                name: "FlightID",
                table: "Holiday");
        }
    }
}
