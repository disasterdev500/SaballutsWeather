

namespace SaballutsWeatherDomain.Models;

public class WeatherRecord
{
    public DateTime Date { get; set; }

    public double IndoorTemperatureC { get; set; }
    public int IndoorHumidityPct { get; set; }
    public double OutdoorTemperatureC { get; set; }
    public int OutdoorHumidityPct { get; set; }

    public double DewPointC { get; set; }

    public double ThermalSensationC { get; set; }

    public double WindSpeedKmH { get; set; }
    public double GustSpeedKmH { get; set; }
    public int WindDirection { get; set; }

    public double AbsolutePressureHpa { get; set; }
    public double RelativePressureHpa { get; set; }

    public double SolarRadiationWm2 { get; set; }
    public int UVI { get; set; }

    public double RainPerHourMm { get; set; }
    public double RainEpisodeMm { get; set; }

    public double RainPerDayMm { get; set; }
    public double RainPerWeekMm { get; set; }
    public double RainPerMonthMm { get; set; }
    public double RainPerYearMm { get; set; }

    public override string ToString()
    {
        return $"Date: {Date}, " +
            $"IndoorTemperature: {IndoorTemperatureC}°C, " +
            $"IndoorHumidity: {IndoorHumidityPct}%, " +
            $"OutdoorTemperature: {OutdoorTemperatureC}°C, " +
            $"OutdoorHumidity: {OutdoorHumidityPct}%, " +
            $"DewPoint: {DewPointC}°C, " +
            $"ThermalSensation: {ThermalSensationC}°C, " +
            $"WindSpeed: {WindSpeedKmH} km/h, " +
            $"GustSpeed: {GustSpeedKmH} km/h, " +
            $"WindDirection: {WindDirection}°, " +
            $"AbsolutePressure: {AbsolutePressureHpa} hPa, " +
            $"RelativePressure: {RelativePressureHpa} hPa, " +
            $"SolarRadiation: {SolarRadiationWm2} W/m², " +
            $"UVI: {UVI}, " +
            $"RainPerHour: {RainPerHourMm} mm, " +
            $"RainEpisode: {RainEpisodeMm} mm, " +
            $"RainPerDay: {RainPerDayMm} mm, " +
            $"RainPerWeek: {RainPerWeekMm} mm, " +
            $"RainPerMonth: {RainPerMonthMm} mm, " +
            $"RainPerYear: {RainPerYearMm} mm";
    }
}