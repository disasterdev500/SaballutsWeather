using CsvHelper.Configuration;
using SaballutsWeatherLoader.Dtos;

namespace SaballutsWeatherLoader.Utilities.Mapper;

public sealed class WeatherCsvMap : ClassMap<CsvWeatherRecord>
{
    public WeatherCsvMap()
    {
        Map(m => m.Timestamp).Name("tiempo");
        Map(m => m.IndoorTemperature).Name("Temperatura interior(℃)");
        Map(m => m.IndoorHumidity).Name("Humedad interior(%)");
        Map(m => m.OutdoorTemperature).Name("Temperatura exterior(℃)");
        Map(m => m.OutdoorHumidity).Name("Humedad exterior(%)");
        Map(m => m.DewPoint).Name("Punto de rocío(℃)");
        Map(m => m.ThermalSensation).Name("Sensación Térmica(℃)");
        Map(m => m.WindSpeed).Name("Viento(km/h)");
        Map(m => m.GustSpeed).Name("Racha(km/h)");
        Map(m => m.WindDirection).Name("Dirección del viento(°)");
        Map(m => m.AbsolutePressure).Name("Presión absoluta(hpa)");
        Map(m => m.RelativePressure).Name("Presión relativa(hpa)");
        Map(m => m.SolarRadiation).Name("Radiación Solar(w/m2)");
        Map(m => m.UVI).Name("UVI");
        Map(m => m.RainPerHour).Name("Lluvia por hora(mm)");
        Map(m => m.RainEpisode).Name("Episodio de lluvia(mm)");
        Map(m => m.RainPerDay).Name("Lluvia por día(mm)");
        Map(m => m.RainPerWeek).Name("Lluvia semanal(mm)");
        Map(m => m.RainPerMonth).Name("Lluvia mensual(mm)");
        Map(m => m.RainPerYear).Name("Lluvia anual(mm)");
    }
}
