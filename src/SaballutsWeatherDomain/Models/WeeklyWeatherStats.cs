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

        Date = dailyWeatherStats[0].Date.GetFirstDayOfWeek();

        MaxIndoorTemperatureC = dailyWeatherStats.Max(r => r.MaxIndoorTemperatureC);
        MinIndoorTemperatureC = dailyWeatherStats.Min(r => r.MinIndoorTemperatureC);
        AverageIndoorTemperatureC = dailyWeatherStats.Average(r => r.AverageIndoorTemperatureC);

        MaxIndoorHumidityPct = dailyWeatherStats.Max(r => r.MaxIndoorHumidityPct);
        MinIndoorHumidityPct = dailyWeatherStats.Min(r => r.MinIndoorHumidityPct);
        AverageIndoorHumidityPct = Convert.ToInt32(dailyWeatherStats.Average(r => r.AverageIndoorHumidityPct));

        MaxOutdoorTemperatureC = dailyWeatherStats.Max(r => r.MaxOutdoorTemperatureC);
        MinOutdoorTemperatureC = dailyWeatherStats.Min(r => r.MinOutdoorTemperatureC);
        AverageOutdoorTemperatureC = dailyWeatherStats.Average(r => r.AverageOutdoorTemperatureC);

        MaxOutdoorHumidityPct = dailyWeatherStats.Max(r => r.MaxOutdoorHumidityPct);
        MinOutdoorHumidityPct = dailyWeatherStats.Min(r => r.MinOutdoorHumidityPct);
        AverageOutdoorHumidityPct = Convert.ToInt32(dailyWeatherStats.Average(r => r.AverageOutdoorHumidityPct));

        DewPointC = dailyWeatherStats.Average(r => r.DewPointC);

        MaxThermalSensationC = dailyWeatherStats.Max(r => r.MaxThermalSensationC);
        MinThermalSensationC = dailyWeatherStats.Min(r => r.MinThermalSensationC);
        AverageThermalSensationC = dailyWeatherStats.Average(r => r.AverageThermalSensationC);

        MaxWindSpeedKmH = dailyWeatherStats.Max(r => r.MaxWindSpeedKmH);
        MinWindSpeedKmH = dailyWeatherStats.Min(r => r.MinWindSpeedKmH);
        AverageWindSpeedKmH = dailyWeatherStats.Average(r => r.AverageWindSpeedKmH);

        MaxGustSpeedKmH = dailyWeatherStats.Max(r => r.MaxGustSpeedKmH);
        MinGustSpeedKmH = dailyWeatherStats.Min(r => r.MinGustSpeedKmH);
        AverageGustSpeedKmH = dailyWeatherStats.Average(r => r.AverageGustSpeedKmH);

        WindDirection = dailyWeatherStats.GroupBy(r => r.WindDirection)
            .OrderByDescending(group => group.Count())
            .First()
            .First().WindDirection;

        MaxAbsolutePressureHpa = dailyWeatherStats.Max(r => r.MaxAbsolutePressureHpa);
        MinAbsolutePressureHpa = dailyWeatherStats.Min(r => r.MinAbsolutePressureHpa);
        AverageAbsolutePressureHpa = dailyWeatherStats.Average(r => r.AverageAbsolutePressureHpa);

        MaxRelativePressureHpa = dailyWeatherStats.Max(r => r.MaxRelativePressureHpa);
        MinRelativePressureHpa = dailyWeatherStats.Min(r => r.MinRelativePressureHpa);
        AverageRelativePressureHpa = dailyWeatherStats.Average(r => r.AverageRelativePressureHpa);

        MaxSolarRadiationWm2 = dailyWeatherStats.Max(r => r.MaxSolarRadiationWm2);
        MinSolarRadiationWm2 = dailyWeatherStats.Min(r => r.MinSolarRadiationWm2);
        AverageSolarRadiationWm2 = dailyWeatherStats.Average(r => r.AverageSolarRadiationWm2);

        MaxUVI = dailyWeatherStats.Max(r => r.MaxUVI);
        MinUVI = dailyWeatherStats.Min(r => r.MinUVI);
        AverageUVI = Convert.ToInt32(dailyWeatherStats.Average(r => r.AverageUVI));

        MaxRainPerHourMm = dailyWeatherStats.Max(r => r.MaxRainPerHourMm);
        MinRainPerHourMm = dailyWeatherStats.Min(r => r.MinRainPerHourMm);
        AverageRainPerHourMm = dailyWeatherStats.Average(r => r.AverageRainPerHourMm);

        MaxRainEpisodeMm = dailyWeatherStats.Max(r => r.MaxRainEpisodeMm);
        MinRainEpisodeMm = dailyWeatherStats.Min(r => r.MinRainEpisodeMm);
        AverageRainEpisodeMm = dailyWeatherStats.Average(r => r.AverageRainEpisodeMm);

        AccumulatedRainMm = dailyWeatherStats.Sum(r => r.AccumulatedRainMm);
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