using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherRepositories.Abstractions;

public interface IDailyWeatherStatsRepository
{
    Task<DailyWeatherStats> GetById(DateTime id);
    Task<List<DailyWeatherStats>> GetByIntervalTimeAsync(DateTime initial, DateTime final);
    Task<DailyWeatherStats> GetFirstAsync();
    Task<DailyWeatherStats> GetLastAsync();
    Task AddAsync(DailyWeatherStats dailyWeatherStats);
    Task SaveAsync();
}
