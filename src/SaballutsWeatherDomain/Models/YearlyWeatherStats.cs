using SaballutsWeatherCommon.Extensions;

namespace SaballutsWeatherDomain.Models;

public class YearlyWeatherStats
{
    public YearlyWeatherStats()
    {

    }
    public YearlyWeatherStats(List<MonthlyWeatherStats> monthlyWeatherStats)
    {
        if (monthlyWeatherStats == null || monthlyWeatherStats.Count == 0)
        {
            throw new ArgumentException("Monthly weather stats list is null or empty.");
        }

        Id = monthlyWeatherStats[0].Id.GetLastDayOfYear();

        MaxIndoorTemperature = monthlyWeatherStats.Max(r => r.MaxIndoorTemperature);
        MaxIndoorTemperatureAt = monthlyWeatherStats.OrderByDescending(r => r.MaxIndoorTemperature).First().MaxIndoorTemperatureAt;
        MinIndoorTemperature = monthlyWeatherStats.Min(r => r.MinIndoorTemperature);
        MinIndoorTemperatureAt = monthlyWeatherStats.OrderBy(r => r.MinIndoorTemperature).First().MinIndoorTemperatureAt;
        AverageIndoorTemperature = monthlyWeatherStats.Average(r => r.AverageIndoorTemperature);

        MaxIndoorHumidity = monthlyWeatherStats.Max(r => r.MaxIndoorHumidity);
        MaxIndoorHumidityAt = monthlyWeatherStats.OrderByDescending(r => r.MaxIndoorHumidity).First().MaxIndoorHumidityAt;
        MinIndoorHumidity = monthlyWeatherStats.Min(r => r.MinIndoorHumidity);
        MinIndoorHumidityAt = monthlyWeatherStats.OrderBy(r => r.MinIndoorHumidity).First().MinIndoorHumidityAt;
        AverageIndoorHumidity = Convert.ToInt32(monthlyWeatherStats.Average(r => r.AverageIndoorHumidity));

        MaxOutdoorTemperature = monthlyWeatherStats.Max(r => r.MaxOutdoorTemperature);
        MaxOutdoorTemperatureAt = monthlyWeatherStats.OrderByDescending(r => r.MaxOutdoorTemperature).First().MaxOutdoorTemperatureAt;
        MinOutdoorTemperature = monthlyWeatherStats.Min(r => r.MinOutdoorTemperature);
        MinOutdoorTemperatureAt = monthlyWeatherStats.OrderBy(r => r.MinOutdoorTemperature).First().MinOutdoorTemperatureAt;
        AverageOutdoorTemperature = monthlyWeatherStats.Average(r => r.AverageOutdoorTemperature);

        MaxOutdoorHumidity = monthlyWeatherStats.Max(r => r.MaxOutdoorHumidity);
        MaxOutdoorHumidityAt = monthlyWeatherStats.OrderByDescending(r => r.MaxOutdoorHumidity).First().MaxOutdoorHumidityAt;
        MinOutdoorHumidity = monthlyWeatherStats.Min(r => r.MinOutdoorHumidity);
        MinOutdoorHumidityAt = monthlyWeatherStats.OrderBy(r => r.MinOutdoorHumidity).First().MinOutdoorHumidityAt;
        AverageOutdoorHumidity = Convert.ToInt32(monthlyWeatherStats.Average(r => r.AverageOutdoorHumidity));

        MaxDewPoint = monthlyWeatherStats.Max(r => r.MaxDewPoint);
        MaxDewPointAt = monthlyWeatherStats.OrderByDescending(r => r.MaxDewPoint).First().MaxDewPointAt;
        MinDewPoint = monthlyWeatherStats.Min(r => r.MinDewPoint);
        MinDewPointAt = monthlyWeatherStats.OrderBy(r => r.MinDewPoint).First().MinDewPointAt;
        AverageDewPoint = monthlyWeatherStats.Average(r => r.AverageDewPoint);

        MaxThermalSensation = monthlyWeatherStats.Max(r => r.MaxThermalSensation);
        MaxThermalSensationAt = monthlyWeatherStats.OrderByDescending(r => r.MaxThermalSensation).First().MaxThermalSensationAt;
        MinThermalSensation = monthlyWeatherStats.Min(r => r.MinThermalSensation);
        MinThermalSensationAt = monthlyWeatherStats.OrderBy(r => r.MinThermalSensation).First().MinThermalSensationAt;
        AverageThermalSensation = monthlyWeatherStats.Average(r => r.AverageThermalSensation);

        MaxWindSpeed = monthlyWeatherStats.Max(r => r.MaxWindSpeed);
        MaxWindSpeedAt = monthlyWeatherStats.OrderByDescending(r => r.MaxWindSpeed).First().MaxWindSpeedAt;
        MinWindSpeed = monthlyWeatherStats.Min(r => r.MinWindSpeed);
        MinWindSpeedAt = monthlyWeatherStats.OrderBy(r => r.MinWindSpeed).First().MinWindSpeedAt;
        AverageWindSpeed = monthlyWeatherStats.Average(r => r.AverageWindSpeed);

        MaxGustSpeed = monthlyWeatherStats.Max(r => r.MaxGustSpeed);
        MaxGustSpeedAt = monthlyWeatherStats.OrderByDescending(r => r.MaxGustSpeed).First().MaxGustSpeedAt;
        MinGustSpeed = monthlyWeatherStats.Min(r => r.MinGustSpeed);
        MinGustSpeedAt = monthlyWeatherStats.OrderBy(r => r.MinGustSpeed).First().MinGustSpeedAt;
        AverageGustSpeed = monthlyWeatherStats.Average(r => r.AverageGustSpeed);

        WindDirection = monthlyWeatherStats.GroupBy(r => r.WindDirection)
            .OrderByDescending(group => group.Count())
            .First()
            .First().WindDirection;

        MaxAbsolutePressure = monthlyWeatherStats.Max(r => r.MaxAbsolutePressure);
        MaxAbsolutePressureAt = monthlyWeatherStats.OrderByDescending(r => r.MaxAbsolutePressure).First().MaxAbsolutePressureAt;
        MinAbsolutePressure = monthlyWeatherStats.Min(r => r.MinAbsolutePressure);
        MinAbsolutePressureAt = monthlyWeatherStats.OrderBy(r => r.MinAbsolutePressure).First().MinAbsolutePressureAt;
        AverageAbsolutePressure = monthlyWeatherStats.Average(r => r.AverageAbsolutePressure);

        MaxRelativePressure = monthlyWeatherStats.Max(r => r.MaxRelativePressure);
        MaxRelativePressureAt = monthlyWeatherStats.OrderByDescending(r => r.MaxRelativePressure).First().MaxRelativePressureAt;
        MinRelativePressure = monthlyWeatherStats.Min(r => r.MinRelativePressure);
        MinRelativePressureAt = monthlyWeatherStats.OrderBy(r => r.MinRelativePressure).First().MinRelativePressureAt;
        AverageRelativePressure = monthlyWeatherStats.Average(r => r.AverageRelativePressure);

        MaxSolarRadiation = monthlyWeatherStats.Max(r => r.MaxSolarRadiation);
        MaxSolarRadiationAt = monthlyWeatherStats.OrderByDescending(r => r.MaxSolarRadiation).First().MaxSolarRadiationAt;
        MinSolarRadiation = monthlyWeatherStats.Min(r => r.MinSolarRadiation);
        MinSolarRadiationAt = monthlyWeatherStats.OrderBy(r => r.MinSolarRadiation).First().MinSolarRadiationAt;
        AverageSolarRadiation = monthlyWeatherStats.Average(r => r.AverageSolarRadiation);

        MaxUVI = monthlyWeatherStats.Max(r => r.MaxUVI);
        MaxUVIAt = monthlyWeatherStats.OrderByDescending(r => r.MaxUVI).First().MaxUVIAt;
        MinUVI = monthlyWeatherStats.Min(r => r.MinUVI);
        MinUVIAt = monthlyWeatherStats.OrderBy(r => r.MinUVI).First().MinUVIAt;
        AverageUVI = Convert.ToInt32(monthlyWeatherStats.Average(r => r.AverageUVI));

        AccumulatedRain = monthlyWeatherStats.Sum(r => r.AccumulatedRain);
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