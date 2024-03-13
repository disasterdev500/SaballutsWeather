using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApplication.Common.Abstractions.Repositories;

public interface IDailyWeatherStatsRepository
{
    Task<DailyWeatherStats> GetById(DateTime id);
    Task<List<DailyWeatherStats>> GetByIntervalTimeAsync(DateTime initial, DateTime final);
    Task<DailyWeatherStats> GetFirstAsync();
    Task<DailyWeatherStats> GetLastAsync();
    Task AddAsync(DailyWeatherStats dailyWeatherStats);
    Task AddRangeAsync(List<DailyWeatherStats> dailyWeatherStats);
    Task BulkUpsertAsync(IEnumerable<DailyWeatherStats> dailyWeatherStats);
    Task SaveAsync();
}
