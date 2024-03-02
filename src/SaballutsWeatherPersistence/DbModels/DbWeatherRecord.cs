using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaballutsWeatherPersistence.DbModels;

public class DbWeatherRecord
{
    [Key]
    public DateTime Date { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public double IndoorTemperatureC { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public int IndoorHumidityPct { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public double OutdoorTemperatureC { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public int OutdoorHumidityPct { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public double DewPointC { get; set; }
    [Column(TypeName = "decimal(4,2)")]

    public double ThermalSensationC { get; set; }
    [Column(TypeName = "decimal(5,2)")]

    public double WindSpeedKmH { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public double GustSpeedKmH { get; set; }
    public int WindDirection { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public double AbsolutePressureHpa { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double RelativePressureHpa { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public double SolarRadiationWm2 { get; set; }
    public int UVI { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public double RainPerHourMm { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double RainEpisodeMm { get; set; }
    [Column(TypeName = "decimal(6,2)")]

    public double RainPerDayMm { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double RainPerWeekMm { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double RainPerMonthMm { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double RainPerYearMm { get; set; }
}