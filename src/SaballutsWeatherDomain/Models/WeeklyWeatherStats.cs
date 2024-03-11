using SaballutsWeatherCommon.Extensions;

namespace SaballutsWeatherDomain.Models;

public class WeeklyWeatherStats
{
    public WeeklyWeatherStats()
    {

    }
    public WeeklyWeatherStats(List<DailyWeatherStats> dailyWeatherStats)
    {
        if (dailyWeatherStats == null || dailyWeatherStats.Count == 0)
        {
            throw new ArgumentException("Daily weather stats list is null or empty.");
        }

        Id = dailyWeatherStats[0].Id.GetFirstDayOfWeek();

        MaxIndoorTemperature = dailyWeatherStats.Max(r => r.MaxIndoorTemperature);
        MaxIndoorTemperatureAt = dailyWeatherStats.OrderByDescending(r => r.MaxIndoorTemperature).First().MaxIndoorTemperatureAt;
        MinIndoorTemperature = dailyWeatherStats.Min(r => r.MinIndoorTemperature);
        MinIndoorTemperatureAt = dailyWeatherStats.OrderBy(r => r.MinIndoorTemperature).First().MinIndoorTemperatureAt;
        AverageIndoorTemperature = dailyWeatherStats.Average(r => r.AverageIndoorTemperature);

        MaxIndoorHumidity = dailyWeatherStats.Max(r => r.MaxIndoorHumidity);
        MaxIndoorHumidityAt = dailyWeatherStats.OrderByDescending(r => r.MaxIndoorHumidity).First().MaxIndoorHumidityAt;
        MinIndoorHumidity = dailyWeatherStats.Min(r => r.MinIndoorHumidity);
        MinIndoorHumidityAt = dailyWeatherStats.OrderBy(r => r.MinIndoorHumidity).First().MinIndoorHumidityAt;
        AverageIndoorHumidity = Convert.ToInt32(dailyWeatherStats.Average(r => r.AverageIndoorHumidity));

        MaxOutdoorTemperature = dailyWeatherStats.Max(r => r.MaxOutdoorTemperature);
        MaxOutdoorTemperatureAt = dailyWeatherStats.OrderByDescending(r => r.MaxOutdoorTemperature).First().MaxOutdoorTemperatureAt;
        MinOutdoorTemperature = dailyWeatherStats.Min(r => r.MinOutdoorTemperature);
        MinOutdoorTemperatureAt = dailyWeatherStats.OrderBy(r => r.MinOutdoorTemperature).First().MinOutdoorTemperatureAt;
        AverageOutdoorTemperature = dailyWeatherStats.Average(r => r.AverageOutdoorTemperature);

        MaxOutdoorHumidity = dailyWeatherStats.Max(r => r.MaxOutdoorHumidity);
        MaxOutdoorHumidityAt = dailyWeatherStats.OrderByDescending(r => r.MaxOutdoorHumidity).First().MaxOutdoorHumidityAt;
        MinOutdoorHumidity = dailyWeatherStats.Min(r => r.MinOutdoorHumidity);
        MinOutdoorHumidityAt = dailyWeatherStats.OrderBy(r => r.MinOutdoorHumidity).First().MinOutdoorHumidityAt;
        AverageOutdoorHumidity = Convert.ToInt32(dailyWeatherStats.Average(r => r.AverageOutdoorHumidity));

        MaxDewPoint = dailyWeatherStats.Max(r => r.MaxDewPoint);
        MaxDewPointAt = dailyWeatherStats.OrderByDescending(r => r.MaxDewPoint).First().MaxDewPointAt;
        MinDewPoint = dailyWeatherStats.Min(r => r.MinDewPoint);
        MinDewPointAt = dailyWeatherStats.OrderBy(r => r.MinDewPoint).First().MinDewPointAt;
        AverageDewPoint = dailyWeatherStats.Average(r => r.AverageDewPoint);

        MaxThermalSensation = dailyWeatherStats.Max(r => r.MaxThermalSensation);
        MaxThermalSensationAt = dailyWeatherStats.OrderByDescending(r => r.MaxThermalSensation).First().MaxThermalSensationAt;
        MinThermalSensation = dailyWeatherStats.Min(r => r.MinThermalSensation);
        MinThermalSensationAt = dailyWeatherStats.OrderBy(r => r.MinThermalSensation).First().MinThermalSensationAt;
        AverageThermalSensation = dailyWeatherStats.Average(r => r.AverageThermalSensation);

        MaxWindSpeed = dailyWeatherStats.Max(r => r.MaxWindSpeed);
        MaxWindSpeedAt = dailyWeatherStats.OrderByDescending(r => r.MaxWindSpeed).First().MaxWindSpeedAt;
        MinWindSpeed = dailyWeatherStats.Min(r => r.MinWindSpeed);
        MinWindSpeedAt = dailyWeatherStats.OrderBy(r => r.MinWindSpeed).First().MinWindSpeedAt;
        AverageWindSpeed = dailyWeatherStats.Average(r => r.AverageWindSpeed);

        MaxGustSpeed = dailyWeatherStats.Max(r => r.MaxGustSpeed);
        MaxGustSpeedAt = dailyWeatherStats.OrderByDescending(r => r.MaxGustSpeed).First().MaxGustSpeedAt;
        MinGustSpeed = dailyWeatherStats.Min(r => r.MinGustSpeed);
        MinGustSpeedAt = dailyWeatherStats.OrderBy(r => r.MinGustSpeed).First().MinGustSpeedAt;
        AverageGustSpeed = dailyWeatherStats.Average(r => r.AverageGustSpeed);

        WindDirection = dailyWeatherStats.GroupBy(r => r.WindDirection)
            .OrderByDescending(group => group.Count())
            .First()
            .First().WindDirection;

        MaxAbsolutePressure = dailyWeatherStats.Max(r => r.MaxAbsolutePressure);
        MaxAbsolutePressureAt = dailyWeatherStats.OrderByDescending(r => r.MaxAbsolutePressure).First().MaxAbsolutePressureAt;
        MinAbsolutePressure = dailyWeatherStats.Min(r => r.MinAbsolutePressure);
        MinAbsolutePressureAt = dailyWeatherStats.OrderBy(r => r.MinAbsolutePressure).First().MinAbsolutePressureAt;
        AverageAbsolutePressure = dailyWeatherStats.Average(r => r.AverageAbsolutePressure);

        MaxRelativePressure = dailyWeatherStats.Max(r => r.MaxRelativePressure);
        MaxRelativePressureAt = dailyWeatherStats.OrderByDescending(r => r.MaxRelativePressure).First().MaxRelativePressureAt;
        MinRelativePressure = dailyWeatherStats.Min(r => r.MinRelativePressure);
        MinRelativePressureAt = dailyWeatherStats.OrderBy(r => r.MinRelativePressure).First().MinRelativePressureAt;
        AverageRelativePressure = dailyWeatherStats.Average(r => r.AverageRelativePressure);

        MaxSolarRadiation = dailyWeatherStats.Max(r => r.MaxSolarRadiation);
        MaxSolarRadiationAt = dailyWeatherStats.OrderByDescending(r => r.MaxSolarRadiation).First().MaxSolarRadiationAt;
        MinSolarRadiation = dailyWeatherStats.Min(r => r.MinSolarRadiation);
        MinSolarRadiationAt = dailyWeatherStats.OrderBy(r => r.MinSolarRadiation).First().MinSolarRadiationAt;
        AverageSolarRadiation = dailyWeatherStats.Average(r => r.AverageSolarRadiation);

        MaxUVI = dailyWeatherStats.Max(r => r.MaxUVI);
        MaxUVIAt = dailyWeatherStats.OrderByDescending(r => r.MaxUVI).First().MaxUVIAt;
        MinUVI = dailyWeatherStats.Min(r => r.MinUVI);
        MinUVIAt = dailyWeatherStats.OrderBy(r => r.MinUVI).First().MinUVIAt;
        AverageUVI = Convert.ToInt32(dailyWeatherStats.Average(r => r.AverageUVI));

        AccumulatedRain = dailyWeatherStats.Sum(r => r.AccumulatedRain);
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