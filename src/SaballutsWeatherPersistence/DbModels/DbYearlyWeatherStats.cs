using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaballutsWeatherPersistence.DbModels;

public class DbYearlyWeatherStats
{
    [Key]
    [Column(TypeName = "date")]
    public DateTime Date { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public double MaxIndoorTemperature { get; set; }
    public DateTime MaxIndoorTemperatureAt { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public double MinIndoorTemperature { get; set; }
    public DateTime MinIndoorTemperatureAt { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public double AverageIndoorTemperature { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public int MaxIndoorHumidity { get; set; }
    public DateTime MaxIndoorHumidityAt { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public int MinIndoorHumidity { get; set; }
    public DateTime MinIndoorHumidityAt { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public int AverageIndoorHumidity { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public double MaxOutdoorTemperature { get; set; }
    public DateTime MaxOutdoorTemperatureAt { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public double MinOutdoorTemperature { get; set; }
    public DateTime MinOutdoorTemperatureAt { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public double AverageOutdoorTemperature { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public int MaxOutdoorHumidity { get; set; }
    public DateTime MaxOutdoorHumidityAt { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public int MinOutdoorHumidity { get; set; }
    public DateTime MinOutdoorHumidityAt { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public int AverageOutdoorHumidity { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public double MaxDewPoint { get; set; }
    public DateTime MaxDewPointAt { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public double MinDewPoint { get; set; }
    public DateTime MinDewPointAt { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public double AverageDewPoint { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public double MaxThermalSensation { get; set; }
    public DateTime MaxThermalSensationAt { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public double MinThermalSensation { get; set; }
    public DateTime MinThermalSensationAt { get; set; }
    [Column(TypeName = "decimal(4,2)")]
    public double AverageThermalSensation { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public double MaxWindSpeed { get; set; }
    public DateTime MaxWindSpeedAt { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public double MinWindSpeed { get; set; }
    public DateTime MinWindSpeedAt { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public double AverageWindSpeed { get; set; }


    [Column(TypeName = "decimal(5,2)")]
    public double MaxGustSpeed { get; set; }
    public DateTime MaxGustSpeedAt { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public double MinGustSpeed { get; set; }
    public DateTime MinGustSpeedAt { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public double AverageGustSpeed { get; set; }

    public int WindDirection { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public double MaxAbsolutePressure { get; set; }
    public DateTime MaxAbsolutePressureAt { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double MinAbsolutePressure { get; set; }
    public DateTime MinAbsolutePressureAt { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double AverageAbsolutePressure { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public double MaxRelativePressure { get; set; }
    public DateTime MaxRelativePressureAt { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double MinRelativePressure { get; set; }
    public DateTime MinRelativePressureAt { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double AverageRelativePressure { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public double MaxSolarRadiation { get; set; }
    public DateTime MaxSolarRadiationAt { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double MinSolarRadiation { get; set; }
    public DateTime MinSolarRadiationAt { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double AverageSolarRadiation { get; set; }

    public int MaxUVI { get; set; }
    public DateTime MaxUVIAt { get; set; }
    public int MinUVI { get; set; }
    public DateTime MinUVIAt { get; set; }
    public int AverageUVI { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public double AccumulatedRain { get; set; }
}
