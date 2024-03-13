using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SaballutsWeatherPersistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRawWeatherRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RawWeatherRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IndoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    IndoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    OutdoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    OutdoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    DewPoint = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    ThermalSensation = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    WindSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    GustSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    WindDirection = table.Column<int>(type: "integer", nullable: false),
                    AbsolutePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    RelativePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    SolarRadiation = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    UVI = table.Column<int>(type: "integer", nullable: false),
                    RainPerHour = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    RainEpisode = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    RainPerDay = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    RainPerWeek = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    RainPerMonth = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    RainPerYear = table.Column<double>(type: "numeric(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawWeatherRecord", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RawWeatherRecord");
        }
    }
}
