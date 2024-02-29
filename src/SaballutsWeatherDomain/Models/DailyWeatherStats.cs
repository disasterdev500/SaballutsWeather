

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

        Date = weatherRecords[0].Date;

        MaxIndoorTemperatureC = weatherRecords.Max(r => r.IndoorTemperatureC);
        MinIndoorTemperatureC = weatherRecords.Min(r => r.IndoorTemperatureC);
        AverageIndoorTemperatureC = weatherRecords.Average(r => r.IndoorTemperatureC);

        MaxIndoorHumidityPct = weatherRecords.Max(r => r.IndoorHumidityPct);
        MinIndoorHumidityPct = weatherRecords.Min(r => r.IndoorHumidityPct);
        AverageIndoorHumidityPct = Convert.ToInt32(weatherRecords.Average(r => r.IndoorHumidityPct));

        MaxOutdoorTemperatureC = weatherRecords.Max(r => r.OutdoorTemperatureC);
        MinOutdoorTemperatureC = weatherRecords.Min(r => r.OutdoorTemperatureC);
        AverageOutdoorTemperatureC = weatherRecords.Average(r => r.OutdoorTemperatureC);

        MaxOutdoorHumidityPct = weatherRecords.Max(r => r.OutdoorHumidityPct);
        MinOutdoorHumidityPct = weatherRecords.Min(r => r.OutdoorHumidityPct);
        AverageOutdoorHumidityPct = Convert.ToInt32(weatherRecords.Average(r => r.OutdoorHumidityPct));

        DewPointC = weatherRecords.Average(r => r.DewPointC);

        MaxThermalSensationC = weatherRecords.Max(r => r.ThermalSensationC);
        MinThermalSensationC = weatherRecords.Min(r => r.ThermalSensationC);
        AverageThermalSensationC = weatherRecords.Average(r => r.ThermalSensationC);

        MaxWindSpeedKmH = weatherRecords.Max(r => r.WindSpeedKmH);
        MinWindSpeedKmH = weatherRecords.Min(r => r.WindSpeedKmH);
        AverageWindSpeedKmH = weatherRecords.Average(r => r.WindSpeedKmH);

        MaxGustSpeedKmH = weatherRecords.Max(r => r.GustSpeedKmH);
        MinGustSpeedKmH = weatherRecords.Min(r => r.GustSpeedKmH);
        AverageGustSpeedKmH = weatherRecords.Average(r => r.GustSpeedKmH);

        WindDirection = weatherRecords.GroupBy(r => r.WindDirection)
            .OrderByDescending(group => group.Count())
            .First()
            .First().WindDirection;

        MaxAbsolutePressureHpa = weatherRecords.Max(r => r.AbsolutePressureHpa);
        MinAbsolutePressureHpa = weatherRecords.Min(r => r.AbsolutePressureHpa);
        AverageAbsolutePressureHpa = weatherRecords.Average(r => r.AbsolutePressureHpa);

        MaxRelativePressureHpa = weatherRecords.Max(r => r.RelativePressureHpa);
        MinRelativePressureHpa = weatherRecords.Min(r => r.RelativePressureHpa);
        AverageRelativePressureHpa = weatherRecords.Average(r => r.RelativePressureHpa);

        MaxSolarRadiationWm2 = weatherRecords.Max(r => r.SolarRadiationWm2);
        MinSolarRadiationWm2 = weatherRecords.Min(r => r.SolarRadiationWm2);
        AverageSolarRadiationWm2 = weatherRecords.Average(r => r.SolarRadiationWm2);

        MaxUVI = weatherRecords.Max(r => r.UVI);
        MinUVI = weatherRecords.Min(r => r.UVI);
        AverageUVI = Convert.ToInt32(weatherRecords.Average(r => r.UVI));

        MaxRainPerHourMm = weatherRecords.Max(r => r.RainPerHourMm);
        MinRainPerHourMm = weatherRecords.Min(r => r.RainPerHourMm);
        AverageRainPerHourMm = weatherRecords.Average(r => r.RainPerHourMm);

        MaxRainEpisodeMm = weatherRecords.Max(r => r.RainEpisodeMm);
        MinRainEpisodeMm = weatherRecords.Min(r => r.RainEpisodeMm);
        AverageRainEpisodeMm = weatherRecords.Average(r => r.RainEpisodeMm);

        AccumulatedRainMm = weatherRecords.Sum(r => r.RainPerHourMm);
    }

    public DateTime Date { get; set; }

    public double MaxIndoorTemperatureC { get; set; }
    public double MinIndoorTemperatureC { get; set; }
    public double AverageIndoorTemperatureC { get; set; }

    public int MaxIndoorHumidityPct { get; set; }
    public int MinIndoorHumidityPct { get; set; }
    public int AverageIndoorHumidityPct { get; set; }

    public double MaxOutdoorTemperatureC { get; set; }
    public double MinOutdoorTemperatureC { get; set; }
    public double AverageOutdoorTemperatureC { get; set; }

    public int MaxOutdoorHumidityPct { get; set; }
    public int MinOutdoorHumidityPct { get; set; }
    public int AverageOutdoorHumidityPct { get; set; }

    public double DewPointC { get; set; }

    public double MaxThermalSensationC { get; set; }
    public double MinThermalSensationC { get; set; }
    public double AverageThermalSensationC { get; set; }

    public double MaxWindSpeedKmH { get; set; }
    public double MinWindSpeedKmH { get; set; }
    public double AverageWindSpeedKmH { get; set; }


    public double MaxGustSpeedKmH { get; set; }
    public double MinGustSpeedKmH { get; set; }
    public double AverageGustSpeedKmH { get; set; }

    public int WindDirection { get; set; }

    public double MaxAbsolutePressureHpa { get; set; }
    public double MinAbsolutePressureHpa { get; set; }
    public double AverageAbsolutePressureHpa { get; set; }

    public double MaxRelativePressureHpa { get; set; }
    public double MinRelativePressureHpa { get; set; }
    public double AverageRelativePressureHpa { get; set; }

    public double MaxSolarRadiationWm2 { get; set; }
    public double MinSolarRadiationWm2 { get; set; }
    public double AverageSolarRadiationWm2 { get; set; }

    public int MaxUVI { get; set; }
    public int MinUVI { get; set; }
    public int AverageUVI { get; set; }

    public double MaxRainPerHourMm { get; set; }
    public double MinRainPerHourMm { get; set; }
    public double AverageRainPerHourMm { get; set; }

    public double MaxRainEpisodeMm { get; set; }
    public double MinRainEpisodeMm { get; set; }
    public double AverageRainEpisodeMm { get; set; }

    public double AccumulatedRainMm { get; set; }

    public override string ToString()
    {
        return $"Date: {Date}, " +
            $"MaxIndoorTemperatureC: {MaxIndoorTemperatureC}, " +
            $"MinIndoorTemperatureC: {MinIndoorTemperatureC}, " +
            $"AverageIndoorTemperatureC: {AverageIndoorTemperatureC}, " +
            $"MaxIndoorHumidityPct: {MaxIndoorHumidityPct}, " +
            $"MinIndoorHumidityPct: {MinIndoorHumidityPct}, " +
            $"AverageIndoorHumidityPct: {AverageIndoorHumidityPct}, " +
            $"MaxOutdoorTemperatureC: {MaxOutdoorTemperatureC}, " +
            $"MinOutdoorTemperatureC: {MinOutdoorTemperatureC}, " +
            $"AverageOutdoorTemperatureC: {AverageOutdoorTemperatureC}, " +
            $"MaxOutdoorHumidityPct: {MaxOutdoorHumidityPct}, " +
            $"MinOutdoorHumidityPct: {MinOutdoorHumidityPct}, " +
            $"AverageOutdoorHumidityPct: {AverageOutdoorHumidityPct}, " +
            $"DewPointC: {DewPointC}, " +
            $"MaxThermalSensationC: {MaxThermalSensationC}, " +
            $"MinThermalSensationC: {MinThermalSensationC}, " +
            $"AverageThermalSensationC: {AverageThermalSensationC}, " +
            $"MaxWindSpeedKmH: {MaxWindSpeedKmH}, " +
            $"MinWindSpeedKmH: {MinWindSpeedKmH}, " +
            $"AverageWindSpeedKmH: {AverageWindSpeedKmH}, " +
            $"MaxGustSpeedKmH: {MaxGustSpeedKmH}, " +
            $"MinGustSpeedKmH: {MinGustSpeedKmH}, " +
            $"AverageGustSpeedKmH: {AverageGustSpeedKmH}, " +
            $"WindDirection: {WindDirection}, " +
            $"MaxAbsolutePressureHpa: {MaxAbsolutePressureHpa}, " +
            $"MinAbsolutePressureHpa: {MinAbsolutePressureHpa}, " +
            $"AverageAbsolutePressureHpa: {AverageAbsolutePressureHpa}, " +
            $"MaxRelativePressureHpa: {MaxRelativePressureHpa}, " +
            $"MinRelativePressureHpa: {MinRelativePressureHpa}, " +
            $"AverageRelativePressureHpa: {AverageRelativePressureHpa}, " +
            $"MaxSolarRadiationWm2: {MaxSolarRadiationWm2}, " +
            $"MinSolarRadiationWm2: {MinSolarRadiationWm2}, " +
            $"AverageSolarRadiationWm2: {AverageSolarRadiationWm2}, " +
            $"MaxUVI: {MaxUVI}, " +
            $"MinUVI: {MinUVI}, " +
            $"AverageUVI: {AverageUVI}, " +
            $"MaxRainPerHourMm: {MaxRainPerHourMm}, " +
            $"MinRainPerHourMm: {MinRainPerHourMm}, " +
            $"AverageRainPerHourMm: {AverageRainPerHourMm}, " +
            $"MaxRainEpisodeMm: {MaxRainEpisodeMm}, " +
            $"MinRainEpisodeMm: {MinRainEpisodeMm}, " +
            $"AverageRainEpisodeMm: {AverageRainEpisodeMm}, " +
            $"AccumulatedRainMm: {AccumulatedRainMm}";
    }
}