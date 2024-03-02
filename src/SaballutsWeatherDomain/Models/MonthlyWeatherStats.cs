using SaballutsWeatherCommon.Extensions;

namespace SaballutsWeatherDomain.Models;

public class MonthlyWeatherStats
{
    public MonthlyWeatherStats()
    {

    }
    public MonthlyWeatherStats(List<WeeklyWeatherStats> weeklyWeatherStats)
    {
        if (weeklyWeatherStats == null || weeklyWeatherStats.Count == 0)
        {
            throw new ArgumentException("Weekly weather stats list is null or empty.");
        }

        Date = weeklyWeatherStats[0].Date.GetFirstDayOfMonth();

        MaxIndoorTemperatureC = weeklyWeatherStats.Max(r => r.MaxIndoorTemperatureC);
        MinIndoorTemperatureC = weeklyWeatherStats.Min(r => r.MinIndoorTemperatureC);
        AverageIndoorTemperatureC = weeklyWeatherStats.Average(r => r.AverageIndoorTemperatureC);

        MaxIndoorHumidityPct = weeklyWeatherStats.Max(r => r.MaxIndoorHumidityPct);
        MinIndoorHumidityPct = weeklyWeatherStats.Min(r => r.MinIndoorHumidityPct);
        AverageIndoorHumidityPct = Convert.ToInt32(weeklyWeatherStats.Average(r => r.AverageIndoorHumidityPct));

        MaxOutdoorTemperatureC = weeklyWeatherStats.Max(r => r.MaxOutdoorTemperatureC);
        MinOutdoorTemperatureC = weeklyWeatherStats.Min(r => r.MinOutdoorTemperatureC);
        AverageOutdoorTemperatureC = weeklyWeatherStats.Average(r => r.AverageOutdoorTemperatureC);

        MaxOutdoorHumidityPct = weeklyWeatherStats.Max(r => r.MaxOutdoorHumidityPct);
        MinOutdoorHumidityPct = weeklyWeatherStats.Min(r => r.MinOutdoorHumidityPct);
        AverageOutdoorHumidityPct = Convert.ToInt32(weeklyWeatherStats.Average(r => r.AverageOutdoorHumidityPct));

        DewPointC = weeklyWeatherStats.Average(r => r.DewPointC);

        MaxThermalSensationC = weeklyWeatherStats.Max(r => r.MaxThermalSensationC);
        MinThermalSensationC = weeklyWeatherStats.Min(r => r.MinThermalSensationC);
        AverageThermalSensationC = weeklyWeatherStats.Average(r => r.AverageThermalSensationC);

        MaxWindSpeedKmH = weeklyWeatherStats.Max(r => r.MaxWindSpeedKmH);
        MinWindSpeedKmH = weeklyWeatherStats.Min(r => r.MinWindSpeedKmH);
        AverageWindSpeedKmH = weeklyWeatherStats.Average(r => r.AverageWindSpeedKmH);

        MaxGustSpeedKmH = weeklyWeatherStats.Max(r => r.MaxGustSpeedKmH);
        MinGustSpeedKmH = weeklyWeatherStats.Min(r => r.MinGustSpeedKmH);
        AverageGustSpeedKmH = weeklyWeatherStats.Average(r => r.AverageGustSpeedKmH);

        WindDirection = weeklyWeatherStats.GroupBy(r => r.WindDirection)
            .OrderByDescending(group => group.Count())
            .First()
            .First().WindDirection;

        MaxAbsolutePressureHpa = weeklyWeatherStats.Max(r => r.MaxAbsolutePressureHpa);
        MinAbsolutePressureHpa = weeklyWeatherStats.Min(r => r.MinAbsolutePressureHpa);
        AverageAbsolutePressureHpa = weeklyWeatherStats.Average(r => r.AverageAbsolutePressureHpa);

        MaxRelativePressureHpa = weeklyWeatherStats.Max(r => r.MaxRelativePressureHpa);
        MinRelativePressureHpa = weeklyWeatherStats.Min(r => r.MinRelativePressureHpa);
        AverageRelativePressureHpa = weeklyWeatherStats.Average(r => r.AverageRelativePressureHpa);

        MaxSolarRadiationWm2 = weeklyWeatherStats.Max(r => r.MaxSolarRadiationWm2);
        MinSolarRadiationWm2 = weeklyWeatherStats.Min(r => r.MinSolarRadiationWm2);
        AverageSolarRadiationWm2 = weeklyWeatherStats.Average(r => r.AverageSolarRadiationWm2);

        MaxUVI = weeklyWeatherStats.Max(r => r.MaxUVI);
        MinUVI = weeklyWeatherStats.Min(r => r.MinUVI);
        AverageUVI = Convert.ToInt32(weeklyWeatherStats.Average(r => r.AverageUVI));

        MaxRainPerHourMm = weeklyWeatherStats.Max(r => r.MaxRainPerHourMm);
        MinRainPerHourMm = weeklyWeatherStats.Min(r => r.MinRainPerHourMm);
        AverageRainPerHourMm = weeklyWeatherStats.Average(r => r.AverageRainPerHourMm);

        MaxRainEpisodeMm = weeklyWeatherStats.Max(r => r.MaxRainEpisodeMm);
        MinRainEpisodeMm = weeklyWeatherStats.Min(r => r.MinRainEpisodeMm);
        AverageRainEpisodeMm = weeklyWeatherStats.Average(r => r.AverageRainEpisodeMm);

        AccumulatedRainMm = weeklyWeatherStats.Sum(r => r.AccumulatedRainMm);
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