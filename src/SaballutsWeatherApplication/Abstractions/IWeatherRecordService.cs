using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApplication.Abstractions;

public interface IWeatherRecordService
{
    Task<WeatherRecord> GetByIDAsync(DateTime timestamp);
    List<WeatherRecord> GetByDateRange(DateTime initial, DateTime final);
    Task AddAsync(WeatherRecord weatherRecord);
    Task AddRangeAsync(List<WeatherRecord> weatherRecords);
}
