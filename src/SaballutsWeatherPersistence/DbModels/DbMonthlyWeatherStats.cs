using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaballutsWeatherPersistence.DbModels;

public class DbMonthlyWeatherStats
{
    [Key]
    [Column(TypeName = "date")]
    public DateTime Date { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public double MaxIndoorTemperatureC { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public double MinIndoorTemperatureC { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public double AverageIndoorTemperatureC { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public int MaxIndoorHumidityPct { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public int MinIndoorHumidityPct { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public int AverageIndoorHumidityPct { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public double MaxOutdoorTemperatureC { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public double MinOutdoorTemperatureC { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public double AverageOutdoorTemperatureC { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public int MaxOutdoorHumidityPct { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public int MinOutdoorHumidityPct { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public int AverageOutdoorHumidityPct { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public double DewPointC { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public double MaxThermalSensationC { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public double MinThermalSensationC { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public double AverageThermalSensationC { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public double MaxWindSpeedKmH { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public double MinWindSpeedKmH { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public double AverageWindSpeedKmH { get; set; }


    [Column(TypeName = "decimal(5,2)")]
    public double MaxGustSpeedKmH { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public double MinGustSpeedKmH { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public double AverageGustSpeedKmH { get; set; }

    public int WindDirection { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public double MaxAbsolutePressureHpa { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double MinAbsolutePressureHpa { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double AverageAbsolutePressureHpa { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public double MaxRelativePressureHpa { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double MinRelativePressureHpa { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double AverageRelativePressureHpa { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public double MaxSolarRadiationWm2 { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double MinSolarRadiationWm2 { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double AverageSolarRadiationWm2 { get; set; }

    public int MaxUVI { get; set; }
    public int MinUVI { get; set; }
    public int AverageUVI { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public double MaxRainPerHourMm { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double MinRainPerHourMm { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double AverageRainPerHourMm { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public double MaxRainEpisodeMm { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double MinRainEpisodeMm { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double AverageRainEpisodeMm { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public double AccumulatedRainMm { get; set; }
}
