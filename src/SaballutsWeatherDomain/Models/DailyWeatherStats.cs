

namespace SaballutsWeatherDomain.Models;

public class DailyWeatherStats
{
    public DailyWeatherStats()
    {

    }
    public DailyWeatherStats(List<WeatherRecord> weatherRecords)
    {
        if (weatherRecords == null || weatherRecords.Count == 0)
        {
            throw new ArgumentException("Weather records list is null or empty.");
        }

        Id = weatherRecords[0].Date.Date;

        MaxIndoorTemperature = weatherRecords.Max(r => r.IndoorTemperature);
        MaxIndoorTemperatureAt = weatherRecords.OrderByDescending(r => r.IndoorTemperature).First().Date;
        MinIndoorTemperature = weatherRecords.Min(r => r.IndoorTemperature);
        MinIndoorTemperatureAt = weatherRecords.OrderBy(r => r.IndoorTemperature).First().Date;
        AverageIndoorTemperature = weatherRecords.Average(r => r.IndoorTemperature);

        MaxIndoorHumidity = weatherRecords.Max(r => r.IndoorHumidity);
        MaxIndoorHumidityAt = weatherRecords.OrderByDescending(r => r.IndoorHumidity).First().Date;
        MinIndoorHumidity = weatherRecords.Min(r => r.IndoorHumidity);
        MinIndoorHumidityAt = weatherRecords.OrderBy(r => r.IndoorHumidity).First().Date;
        AverageIndoorHumidity = Convert.ToInt32(weatherRecords.Average(r => r.IndoorHumidity));

        MaxOutdoorTemperature = weatherRecords.Max(r => r.OutdoorTemperature);
        MaxOutdoorTemperatureAt = weatherRecords.OrderByDescending(r => r.OutdoorTemperature).First().Date;
        MinOutdoorTemperature = weatherRecords.Min(r => r.OutdoorTemperature);
        MinOutdoorTemperatureAt = weatherRecords.OrderBy(r => r.OutdoorTemperature).First().Date;
        AverageOutdoorTemperature = weatherRecords.Average(r => r.OutdoorTemperature);

        MaxOutdoorHumidity = weatherRecords.Max(r => r.OutdoorHumidity);
        MaxOutdoorHumidityAt = weatherRecords.OrderByDescending(r => r.OutdoorHumidity).First().Date;
        MinOutdoorHumidity = weatherRecords.Min(r => r.OutdoorHumidity);
        MinOutdoorHumidityAt = weatherRecords.OrderBy(r => r.OutdoorHumidity).First().Date;
        AverageOutdoorHumidity = Convert.ToInt32(weatherRecords.Average(r => r.OutdoorHumidity));

        MaxDewPoint = weatherRecords.Max(r => r.DewPoint);
        MaxDewPointAt = weatherRecords.OrderByDescending(r => r.DewPoint).First().Date;
        MinDewPoint = weatherRecords.Min(r => r.DewPoint);
        MinDewPointAt = weatherRecords.OrderBy(r => r.DewPoint).First().Date;
        AverageDewPoint = weatherRecords.Average(r => r.DewPoint);

        MaxThermalSensation = weatherRecords.Max(r => r.ThermalSensation);
        MaxThermalSensationAt = weatherRecords.OrderByDescending(r => r.ThermalSensation).First().Date;
        MinThermalSensation = weatherRecords.Min(r => r.ThermalSensation);
        MinThermalSensationAt = weatherRecords.OrderBy(r => r.ThermalSensation).First().Date;
        AverageThermalSensation = weatherRecords.Average(r => r.ThermalSensation);

        MaxWindSpeed = weatherRecords.Max(r => r.WindSpeed);
        MaxWindSpeedAt = weatherRecords.OrderByDescending(r => r.WindSpeed).First().Date;
        MinWindSpeed = weatherRecords.Min(r => r.WindSpeed);
        MinWindSpeedAt = weatherRecords.OrderBy(r => r.WindSpeed).First().Date;
        AverageWindSpeed = weatherRecords.Average(r => r.WindSpeed);

        MaxGustSpeed = weatherRecords.Max(r => r.GustSpeed);
        MaxGustSpeedAt = weatherRecords.OrderByDescending(r => r.GustSpeed).First().Date;
        MinGustSpeed = weatherRecords.Min(r => r.GustSpeed);
        MinGustSpeedAt = weatherRecords.OrderBy(r => r.GustSpeed).First().Date;
        AverageGustSpeed = weatherRecords.Average(r => r.GustSpeed);

        WindDirection = weatherRecords.GroupBy(r => r.WindDirection)
            .OrderByDescending(group => group.Count())
            .First()
            .First().WindDirection;

        MaxAbsolutePressure = weatherRecords.Max(r => r.AbsolutePressure);
        MaxAbsolutePressureAt = weatherRecords.OrderByDescending(r => r.AbsolutePressure).First().Date;
        MinAbsolutePressure = weatherRecords.Min(r => r.AbsolutePressure);
        MinAbsolutePressureAt = weatherRecords.OrderBy(r => r.AbsolutePressure).First().Date;
        AverageAbsolutePressure = weatherRecords.Average(r => r.AbsolutePressure);

        MaxRelativePressure = weatherRecords.Max(r => r.RelativePressure);
        MaxRelativePressureAt = weatherRecords.OrderByDescending(r => r.RelativePressure).First().Date;
        MinRelativePressure = weatherRecords.Min(r => r.RelativePressure);
        MinRelativePressureAt = weatherRecords.OrderBy(r => r.RelativePressure).First().Date;
        AverageRelativePressure = weatherRecords.Average(r => r.RelativePressure);

        MaxSolarRadiation = weatherRecords.Max(r => r.SolarRadiation);
        MaxSolarRadiationAt = weatherRecords.OrderByDescending(r => r.SolarRadiation).First().Date;
        MinSolarRadiation = weatherRecords.Min(r => r.SolarRadiation);
        MinSolarRadiationAt = weatherRecords.OrderBy(r => r.SolarRadiation).First().Date;
        AverageSolarRadiation = weatherRecords.Average(r => r.SolarRadiation);

        MaxUVI = weatherRecords.Max(r => r.UVI);
        MaxUVIAt = weatherRecords.OrderByDescending(r => r.UVI).First().Date;
        MinUVI = weatherRecords.Min(r => r.UVI);
        MinUVIAt = weatherRecords.OrderBy(r => r.UVI).First().Date;
        AverageUVI = Convert.ToInt32(weatherRecords.Average(r => r.UVI));

        AccumulatedRain = weatherRecords.Sum(r => r.RainPerHour);
    }

    public DateTime Id { get; set; }

    public double MaxIndoorTemperature { get; set; }
    public DateTime MaxIndoorTemperatureAt { get; set; }
    public double MinIndoorTemperature { get; set; }
    public DateTime MinIndoorTemperatureAt { get; set; }
    public double AverageIndoorTemperature { get; set; }

    public int MaxIndoorHumidity { get; set; }
    public DateTime MaxIndoorHumidityAt { get; set; }
    public int MinIndoorHumidity { get; set; }
    public DateTime MinIndoorHumidityAt { get; set; }
    public int AverageIndoorHumidity { get; set; }

    public double MaxOutdoorTemperature { get; set; }
    public DateTime MaxOutdoorTemperatureAt { get; set; }
    public double MinOutdoorTemperature { get; set; }
    public DateTime MinOutdoorTemperatureAt { get; set; }
    public double AverageOutdoorTemperature { get; set; }

    public int MaxOutdoorHumidity { get; set; }
    public DateTime MaxOutdoorHumidityAt { get; set; }
    public int MinOutdoorHumidity { get; set; }
    public DateTime MinOutdoorHumidityAt { get; set; }
    public int AverageOutdoorHumidity { get; set; }

    public double MaxDewPoint { get; set; }
    public DateTime MaxDewPointAt { get; set; }
    public double MinDewPoint { get; set; }
    public DateTime MinDewPointAt { get; set; }
    public double AverageDewPoint { get; set; }

    public double MaxThermalSensation { get; set; }
    public DateTime MaxThermalSensationAt { get; set; }
    public double MinThermalSensation { get; set; }
    public DateTime MinThermalSensationAt { get; set; }
    public double AverageThermalSensation { get; set; }

    public double MaxWindSpeed { get; set; }
    public DateTime MaxWindSpeedAt { get; set; }
    public double MinWindSpeed { get; set; }
    public DateTime MinWindSpeedAt { get; set; }
    public double AverageWindSpeed { get; set; }


    public double MaxGustSpeed { get; set; }
    public DateTime MaxGustSpeedAt { get; set; }
    public double MinGustSpeed { get; set; }
    public DateTime MinGustSpeedAt { get; set; }
    public double AverageGustSpeed { get; set; }

    public int WindDirection { get; set; }

    public double MaxAbsolutePressure { get; set; }
    public DateTime MaxAbsolutePressureAt { get; set; }
    public double MinAbsolutePressure { get; set; }
    public DateTime MinAbsolutePressureAt { get; set; }
    public double AverageAbsolutePressure { get; set; }

    public double MaxRelativePressure { get; set; }
    public DateTime MaxRelativePressureAt { get; set; }
    public double MinRelativePressure { get; set; }
    public DateTime MinRelativePressureAt { get; set; }
    public double AverageRelativePressure { get; set; }

    public double MaxSolarRadiation { get; set; }
    public DateTime MaxSolarRadiationAt { get; set; }
    public double MinSolarRadiation { get; set; }
    public DateTime MinSolarRadiationAt { get; set; }
    public double AverageSolarRadiation { get; set; }

    public int MaxUVI { get; set; }
    public DateTime MaxUVIAt { get; set; }
    public int MinUVI { get; set; }
    public DateTime MinUVIAt { get; set; }
    public int AverageUVI { get; set; }

    public double AccumulatedRain { get; set; }

    public override string ToString()
    {
        return $"Date: {Id}, " +
            $"MaxIndoorTemperature: {MaxIndoorTemperature}, " +
            $"MaxIndoorTemperatureAt: {MaxIndoorTemperatureAt}, " +
            $"MinIndoorTemperature: {MinIndoorTemperature}, " +
            $"MinIndoorTemperatureAt: {MinIndoorTemperatureAt}, " +
            $"AverageIndoorTemperature: {AverageIndoorTemperature}, " +
            $"MaxIndoorHumidity: {MaxIndoorHumidity}, " +
            $"MaxIndoorHumidityAt: {MaxIndoorHumidityAt}, " +
            $"MinIndoorHumidity: {MinIndoorHumidity}, " +
            $"MinIndoorHumidityAt: {MinIndoorHumidityAt}, " +
            $"AverageIndoorHumidity: {AverageIndoorHumidity}, " +
            $"MaxOutdoorTemperature: {MaxOutdoorTemperature}, " +
            $"MaxOutdoorTemperatureAt: {MaxOutdoorTemperatureAt}, " +
            $"MinOutdoorTemperature: {MinOutdoorTemperature}, " +
            $"MinOutdoorTemperatureAt: {MinOutdoorTemperatureAt}, " +
            $"AverageOutdoorTemperature: {AverageOutdoorTemperature}, " +
            $"MaxOutdoorHumidity: {MaxOutdoorHumidity}, " +
            $"MaxOutdoorHumidityAt: {MaxOutdoorHumidityAt}, " +
            $"MinOutdoorHumidity: {MinOutdoorHumidity}, " +
            $"MinOutdoorHumidityAt: {MinOutdoorHumidityAt}, " +
            $"AverageOutdoorHumidity: {AverageOutdoorHumidity}, " +
            $"MaxDewPoint: {MaxDewPoint}, " +
            $"MaxDewPointAt: {MaxDewPointAt}, " +
            $"MinDewPoint: {MinDewPoint}, " +
            $"MinDewPointAt: {MinDewPointAt}, " +
            $"AverageDewPoint: {AverageDewPoint}, " +
            $"MaxThermalSensation: {MaxThermalSensation}, " +
            $"MaxThermalSensationAt: {MaxThermalSensationAt}, " +
            $"MinThermalSensation: {MinThermalSensation}, " +
            $"MinThermalSensationAt: {MinThermalSensationAt}, " +
            $"AverageThermalSensation: {AverageThermalSensation}, " +
            $"MaxWindSpeed: {MaxWindSpeed}, " +
            $"MaxWindSpeedAt: {MaxWindSpeedAt}, " +
            $"MinWindSpeed: {MinWindSpeed}, " +
            $"MinWindSpeedAt: {MinWindSpeedAt}, " +
            $"AverageWindSpeed: {AverageWindSpeed}, " +
            $"MaxGustSpeed: {MaxGustSpeed}, " +
            $"MaxGustSpeedAt: {MaxGustSpeedAt}, " +
            $"MinGustSpeed: {MinGustSpeed}, " +
            $"MinGustSpeedAt: {MinGustSpeedAt}, " +
            $"AverageGustSpeed: {AverageGustSpeed}, " +
            $"WindDirection: {WindDirection}, " +
            $"MaxAbsolutePressure: {MaxAbsolutePressure}, " +
            $"MaxAbsolutePressureAt: {MaxAbsolutePressureAt}, " +
            $"MinAbsolutePressure: {MinAbsolutePressure}, " +
            $"MinAbsolutePressureAt: {MinAbsolutePressureAt}, " +
            $"AverageAbsolutePressure: {AverageAbsolutePressure}, " +
            $"MaxRelativePressure: {MaxRelativePressure}, " +
            $"MaxRelativePressureAt: {MaxRelativePressureAt}, " +
            $"MinRelativePressure: {MinRelativePressure}, " +
            $"MinRelativePressureAt: {MinRelativePressureAt}, " +
            $"AverageRelativePressure: {AverageRelativePressure}, " +
            $"MaxSolarRadiation: {MaxSolarRadiation}, " +
            $"MaxSolarRadiationAt: {MaxSolarRadiationAt}, " +
            $"MinSolarRadiation: {MinSolarRadiation}, " +
            $"MinSolarRadiationAt: {MinSolarRadiationAt}, " +
            $"AverageSolarRadiation: {AverageSolarRadiation}, " +
            $"MaxUVI: {MaxUVI}, " +
            $"MaxUVIAt: {MaxUVIAt}, " +
            $"MinUVI: {MinUVI}, " +
            $"MinUVIAt: {MinUVIAt}, " +
            $"AverageUVI: {AverageUVI}, " +
            $"AccumulatedRain: {AccumulatedRain}";
    }
}