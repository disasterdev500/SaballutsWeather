using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApplication.Common.Abstractions.Repositories;

public interface IWeatherRecordsRepository
{
    Task<WeatherRecord> GetById(DateTime id);
    Task<List<WeatherRecord>> GetByIntervalTimeAsync(DateTime initial, DateTime final);
    Task<WeatherRecord> GetLastAsync();
    Task<WeatherRecord> GetFirstAsync();
    Task AddAsync(WeatherRecord weatherRecord);
    Task AddRangeAsync(IEnumerable<WeatherRecord> weatherRecords);
    Task BulkUpsertAsync(IEnumerable<WeatherRecord> weatherRecords);
    Task SaveAsync();
}
