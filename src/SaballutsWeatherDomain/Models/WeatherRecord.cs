

namespace SaballutsWeatherDomain.Models;

public class WeatherRecord
{
    public DateTime Date { get; set; }

    public double IndoorTemperature { get; set; }
    public int IndoorHumidity { get; set; }
    public double OutdoorTemperature { get; set; }
    public int OutdoorHumidity { get; set; }

    public double DewPoint { get; set; }

    public double ThermalSensation { get; set; }

    public double WindSpeed { get; set; }
    public double GustSpeed { get; set; }
    public int WindDirection { get; set; }

    public double AbsolutePressure { get; set; }
    public double RelativePressure { get; set; }

    public double SolarRadiation { get; set; }
    public int UVI { get; set; }

    public double RainPerHour { get; set; }
    public double RainEpisode { get; set; }

    public double RainPerDay { get; set; }
    public double RainPerWeek { get; set; }
    public double RainPerMonth { get; set; }
    public double RainPerYear { get; set; }

    public override string ToString()
    {
        return $"Date: {Date}, " +
            $"IndoorTemperature: {IndoorTemperature}°C(degree Celsius), " +
            $"IndoorHumidity: {IndoorHumidity}%(percentage), " +
            $"OutdoorTemperature: {OutdoorTemperature}°C(degree Celsius), " +
            $"OutdoorHumidity: {OutdoorHumidity}%(percentage), " +
            $"DewPoint: {DewPoint}°C(degree Celsius), " +
            $"ThermalSensation: {ThermalSensation}°C(degree Celsius), " +
            $"WindSpeed: {WindSpeed} km/h (Kilometres per hour), " +
            $"GustSpeed: {GustSpeed} km/h (Kilometres per hour), " +
            $"WindDirection: {WindDirection}°, " +
            $"AbsolutePressure: {AbsolutePressure} hPa (Hectopascal), " +
            $"RelativePressure: {RelativePressure} hPa (Hectopascal), " +
            $"SolarRadiation: {SolarRadiation} W/m²(watts per square metre), " +
            $"UVI: {UVI} (Ultra Violet Radiation Index ), " +
            $"RainPerHour: {RainPerHour} mm(milliliter), " +
            $"RainEpisode: {RainEpisode} mm(milliliter), " +
            $"RainPerDay: {RainPerDay} mm(milliliter), " +
            $"RainPerWeek: {RainPerWeek} mm(milliliter), " +
            $"RainPerMonth: {RainPerMonth} mm(milliliter), " +
            $"RainPerYear: {RainPerYear} mm(milliliter)";
    }
}