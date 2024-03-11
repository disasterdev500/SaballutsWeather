using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaballutsWeatherPersistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyWeatherStats",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    MaxIndoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxIndoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinIndoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinIndoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageIndoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxIndoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxIndoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinIndoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MinIndoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageIndoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxOutdoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxOutdoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinOutdoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinOutdoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageOutdoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxOutdoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxOutdoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinOutdoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MinOutdoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageOutdoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxDewPoint = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxDewPointAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinDewPoint = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinDewPointAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageDewPoint = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxThermalSensation = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxThermalSensationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinThermalSensation = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinThermalSensationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageThermalSensation = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxWindSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MaxWindSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinWindSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MinWindSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageWindSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MaxGustSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MaxGustSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinGustSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MinGustSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageGustSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    WindDirection = table.Column<int>(type: "integer", nullable: false),
                    MaxAbsolutePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxAbsolutePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinAbsolutePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MinAbsolutePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageAbsolutePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxRelativePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxRelativePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinRelativePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MinRelativePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageRelativePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxSolarRadiation = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxSolarRadiationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinSolarRadiation = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MinSolarRadiationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageSolarRadiation = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxUVI = table.Column<int>(type: "integer", nullable: false),
                    MaxUVIAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinUVI = table.Column<int>(type: "integer", nullable: false),
                    MinUVIAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageUVI = table.Column<int>(type: "integer", nullable: false),
                    AccumulatedRain = table.Column<double>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyWeatherStats", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyWeatherStats",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    MaxIndoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxIndoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinIndoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinIndoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageIndoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxIndoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxIndoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinIndoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MinIndoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageIndoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxOutdoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxOutdoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinOutdoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinOutdoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageOutdoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxOutdoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxOutdoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinOutdoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MinOutdoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageOutdoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxDewPoint = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxDewPointAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinDewPoint = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinDewPointAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageDewPoint = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxThermalSensation = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxThermalSensationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinThermalSensation = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinThermalSensationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageThermalSensation = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxWindSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MaxWindSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinWindSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MinWindSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageWindSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MaxGustSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MaxGustSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinGustSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MinGustSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageGustSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    WindDirection = table.Column<int>(type: "integer", nullable: false),
                    MaxAbsolutePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxAbsolutePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinAbsolutePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MinAbsolutePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageAbsolutePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxRelativePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxRelativePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinRelativePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MinRelativePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageRelativePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxSolarRadiation = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxSolarRadiationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinSolarRadiation = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MinSolarRadiationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageSolarRadiation = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxUVI = table.Column<int>(type: "integer", nullable: false),
                    MaxUVIAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinUVI = table.Column<int>(type: "integer", nullable: false),
                    MinUVIAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageUVI = table.Column<int>(type: "integer", nullable: false),
                    AccumulatedRain = table.Column<double>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyWeatherStats", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "WeatherRecord",
                columns: table => new
                {
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
                    table.PrimaryKey("PK_WeatherRecord", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyWeatherStats",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    MaxIndoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxIndoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinIndoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinIndoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageIndoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxIndoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxIndoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinIndoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MinIndoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageIndoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxOutdoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxOutdoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinOutdoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinOutdoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageOutdoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxOutdoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxOutdoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinOutdoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MinOutdoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageOutdoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxDewPoint = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxDewPointAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinDewPoint = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinDewPointAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageDewPoint = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxThermalSensation = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxThermalSensationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinThermalSensation = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinThermalSensationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageThermalSensation = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxWindSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MaxWindSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinWindSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MinWindSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageWindSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MaxGustSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MaxGustSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinGustSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MinGustSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageGustSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    WindDirection = table.Column<int>(type: "integer", nullable: false),
                    MaxAbsolutePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxAbsolutePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinAbsolutePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MinAbsolutePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageAbsolutePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxRelativePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxRelativePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinRelativePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MinRelativePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageRelativePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxSolarRadiation = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxSolarRadiationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinSolarRadiation = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MinSolarRadiationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageSolarRadiation = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxUVI = table.Column<int>(type: "integer", nullable: false),
                    MaxUVIAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinUVI = table.Column<int>(type: "integer", nullable: false),
                    MinUVIAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageUVI = table.Column<int>(type: "integer", nullable: false),
                    AccumulatedRain = table.Column<double>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyWeatherStats", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "YearlyWeatherStats",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    MaxIndoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxIndoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinIndoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinIndoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageIndoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxIndoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxIndoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinIndoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MinIndoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageIndoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxOutdoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxOutdoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinOutdoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinOutdoorTemperatureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageOutdoorTemperature = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxOutdoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxOutdoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinOutdoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MinOutdoorHumidityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageOutdoorHumidity = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    MaxDewPoint = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxDewPointAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinDewPoint = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinDewPointAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageDewPoint = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxThermalSensation = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxThermalSensationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinThermalSensation = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MinThermalSensationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageThermalSensation = table.Column<double>(type: "numeric(4,2)", nullable: false),
                    MaxWindSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MaxWindSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinWindSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MinWindSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageWindSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MaxGustSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MaxGustSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinGustSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    MinGustSpeedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageGustSpeed = table.Column<double>(type: "numeric(5,2)", nullable: false),
                    WindDirection = table.Column<int>(type: "integer", nullable: false),
                    MaxAbsolutePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxAbsolutePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinAbsolutePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MinAbsolutePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageAbsolutePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxRelativePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxRelativePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinRelativePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MinRelativePressureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageRelativePressure = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxSolarRadiation = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxSolarRadiationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinSolarRadiation = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MinSolarRadiationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageSolarRadiation = table.Column<double>(type: "numeric(6,2)", nullable: false),
                    MaxUVI = table.Column<int>(type: "integer", nullable: false),
                    MaxUVIAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinUVI = table.Column<int>(type: "integer", nullable: false),
                    MinUVIAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AverageUVI = table.Column<int>(type: "integer", nullable: false),
                    AccumulatedRain = table.Column<double>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearlyWeatherStats", x => x.Date);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyWeatherStats");

            migrationBuilder.DropTable(
                name: "MonthlyWeatherStats");

            migrationBuilder.DropTable(
                name: "WeatherRecord");

            migrationBuilder.DropTable(
                name: "WeeklyWeatherStats");

            migrationBuilder.DropTable(
                name: "YearlyWeatherStats");
        }
    }
}
