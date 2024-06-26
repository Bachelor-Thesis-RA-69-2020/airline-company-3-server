using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineCompany3.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iata = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LatitudeDegrees = table.Column<float>(type: "real", nullable: false),
                    LongitudeDegrees = table.Column<float>(type: "real", nullable: false),
                    ElevationMeters = table.Column<float>(type: "real", nullable: false),
                    Continent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ScheduledDeparture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledArrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TravelTime = table.Column<int>(type: "int", nullable: false),
                    BaggageGuidelines = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    KidsDiscount = table.Column<float>(type: "real", nullable: false),
                    StartingPointId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EndingPointId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_EndingPointId",
                        column: x => x.EndingPointId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_StartingPointId",
                        column: x => x.StartingPointId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_EndingPointId",
                table: "Flights",
                column: "EndingPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_StartingPointId",
                table: "Flights",
                column: "StartingPointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
