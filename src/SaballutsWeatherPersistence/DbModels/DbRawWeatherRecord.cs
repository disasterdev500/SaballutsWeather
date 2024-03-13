using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaballutsWeatherPersistence.DbModels;

public class DbRawWeatherRecord
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime Date { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public double IndoorTemperature { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public int IndoorHumidity { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public double OutdoorTemperature { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public int OutdoorHumidity { get; set; }

    [Column(TypeName = "decimal(4,2)")]
    public double DewPoint { get; set; }
    [Column(TypeName = "decimal(4,2)")]

    public double ThermalSensation { get; set; }
    [Column(TypeName = "decimal(5,2)")]

    public double WindSpeed { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public double GustSpeed { get; set; }
    public int WindDirection { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public double AbsolutePressure { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double RelativePressure { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public double SolarRadiation { get; set; }
    public int UVI { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public double RainPerHour { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double RainEpisode { get; set; }
    [Column(TypeName = "decimal(6,2)")]

    public double RainPerDay { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double RainPerWeek { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double RainPerMonth { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public double RainPerYear { get; set; }
}