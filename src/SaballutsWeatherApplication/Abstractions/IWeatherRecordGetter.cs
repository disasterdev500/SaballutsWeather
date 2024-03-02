using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApplication.Abstractions;

public interface IWeatherRecordGetter
{
    Task<WeatherRecord> GetByIDAsync(DateTime timestamp);
}
