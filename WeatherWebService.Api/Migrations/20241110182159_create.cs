using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherWebService.Api.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "precipitation_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__precipit__3213E83F7BFC1739", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    country = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__regions__3213E83F9DACBC9D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    latitude = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    longitude = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    region_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cities__3213E83FDBFBDEF4", x => x.id);
                    table.ForeignKey(
                        name: "FK__cities__region_i__398D8EEE",
                        column: x => x.region_id,
                        principalTable: "regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "weather_stations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: true),
                    installation_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__weather___3213E83FD8E525F1", x => x.id);
                    table.ForeignKey(
                        name: "FK__weather_s__city___3C69FB99",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "observations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    station_id = table.Column<int>(type: "int", nullable: true),
                    observation_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    temperature = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    humidity = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    wind_speed = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    precipitation = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    precipitation_type_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__observat__3213E83F8D9ECA23", x => x.id);
                    table.ForeignKey(
                        name: "FK__observati__preci__47DBAE45",
                        column: x => x.precipitation_type_id,
                        principalTable: "precipitation_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK__observati__stati__46E78A0C",
                        column: x => x.station_id,
                        principalTable: "weather_stations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cities_region_id",
                table: "cities",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "IX_observations_precipitation_type_id",
                table: "observations",
                column: "precipitation_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_observations_station_id",
                table: "observations",
                column: "station_id");

            migrationBuilder.CreateIndex(
                name: "IX_weather_stations_city_id",
                table: "weather_stations",
                column: "city_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "observations");

            migrationBuilder.DropTable(
                name: "precipitation_types");

            migrationBuilder.DropTable(
                name: "weather_stations");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "regions");
        }
    }
}
