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
            throw new ArgumentException("Weekly weather stats list is null or empty.");
        }

        Date = monthlyWeatherStats[0].Date.GetFirstDayOfYear();

        MaxIndoorTemperatureC = monthlyWeatherStats.Max(r => r.MaxIndoorTemperatureC);
        MinIndoorTemperatureC = monthlyWeatherStats.Min(r => r.MinIndoorTemperatureC);
        AverageIndoorTemperatureC = monthlyWeatherStats.Average(r => r.AverageIndoorTemperatureC);

        MaxIndoorHumidityPct = monthlyWeatherStats.Max(r => r.MaxIndoorHumidityPct);
        MinIndoorHumidityPct = monthlyWeatherStats.Min(r => r.MinIndoorHumidityPct);
        AverageIndoorHumidityPct = Convert.ToInt32(monthlyWeatherStats.Average(r => r.AverageIndoorHumidityPct));

        MaxOutdoorTemperatureC = monthlyWeatherStats.Max(r => r.MaxOutdoorTemperatureC);
        MinOutdoorTemperatureC = monthlyWeatherStats.Min(r => r.MinOutdoorTemperatureC);
        AverageOutdoorTemperatureC = monthlyWeatherStats.Average(r => r.AverageOutdoorTemperatureC);

        MaxOutdoorHumidityPct = monthlyWeatherStats.Max(r => r.MaxOutdoorHumidityPct);
        MinOutdoorHumidityPct = monthlyWeatherStats.Min(r => r.MinOutdoorHumidityPct);
        AverageOutdoorHumidityPct = Convert.ToInt32(monthlyWeatherStats.Average(r => r.AverageOutdoorHumidityPct));

        DewPointC = monthlyWeatherStats.Average(r => r.DewPointC);

        MaxThermalSensationC = monthlyWeatherStats.Max(r => r.MaxThermalSensationC);
        MinThermalSensationC = monthlyWeatherStats.Min(r => r.MinThermalSensationC);
        AverageThermalSensationC = monthlyWeatherStats.Average(r => r.AverageThermalSensationC);

        MaxWindSpeedKmH = monthlyWeatherStats.Max(r => r.MaxWindSpeedKmH);
        MinWindSpeedKmH = monthlyWeatherStats.Min(r => r.MinWindSpeedKmH);
        AverageWindSpeedKmH = monthlyWeatherStats.Average(r => r.AverageWindSpeedKmH);

        MaxGustSpeedKmH = monthlyWeatherStats.Max(r => r.MaxGustSpeedKmH);
        MinGustSpeedKmH = monthlyWeatherStats.Min(r => r.MinGustSpeedKmH);
        AverageGustSpeedKmH = monthlyWeatherStats.Average(r => r.AverageGustSpeedKmH);

        WindDirection = monthlyWeatherStats.GroupBy(r => r.WindDirection)
            .OrderByDescending(group => group.Count())
            .First()
            .First().WindDirection;

        MaxAbsolutePressureHpa = monthlyWeatherStats.Max(r => r.MaxAbsolutePressureHpa);
        MinAbsolutePressureHpa = monthlyWeatherStats.Min(r => r.MinAbsolutePressureHpa);
        AverageAbsolutePressureHpa = monthlyWeatherStats.Average(r => r.AverageAbsolutePressureHpa);

        MaxRelativePressureHpa = monthlyWeatherStats.Max(r => r.MaxRelativePressureHpa);
        MinRelativePressureHpa = monthlyWeatherStats.Min(r => r.MinRelativePressureHpa);
        AverageRelativePressureHpa = monthlyWeatherStats.Average(r => r.AverageRelativePressureHpa);

        MaxSolarRadiationWm2 = monthlyWeatherStats.Max(r => r.MaxSolarRadiationWm2);
        MinSolarRadiationWm2 = monthlyWeatherStats.Min(r => r.MinSolarRadiationWm2);
        AverageSolarRadiationWm2 = monthlyWeatherStats.Average(r => r.AverageSolarRadiationWm2);

        MaxUVI = monthlyWeatherStats.Max(r => r.MaxUVI);
        MinUVI = monthlyWeatherStats.Min(r => r.MinUVI);
        AverageUVI = Convert.ToInt32(monthlyWeatherStats.Average(r => r.AverageUVI));

        MaxRainPerHourMm = monthlyWeatherStats.Max(r => r.MaxRainPerHourMm);
        MinRainPerHourMm = monthlyWeatherStats.Min(r => r.MinRainPerHourMm);
        AverageRainPerHourMm = monthlyWeatherStats.Average(r => r.AverageRainPerHourMm);

        MaxRainEpisodeMm = monthlyWeatherStats.Max(r => r.MaxRainEpisodeMm);
        MinRainEpisodeMm = monthlyWeatherStats.Min(r => r.MinRainEpisodeMm);
        AverageRainEpisodeMm = monthlyWeatherStats.Average(r => r.AverageRainEpisodeMm);

        AccumulatedRainMm = monthlyWeatherStats.Sum(r => r.AccumulatedRainMm);
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