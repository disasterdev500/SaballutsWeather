using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApplication.Abstractions;

public interface IWeatherRecordService
{
    Task<WeatherRecord> GetByIDAsync(DateTime timestamp);
}
