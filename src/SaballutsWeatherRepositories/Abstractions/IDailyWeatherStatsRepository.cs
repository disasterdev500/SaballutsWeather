using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherRepositories.Abstractions;

public interface IDailyWeatherStatsRepository
{
    Task<DailyWeatherStats> GetById(DateTime id);
    List<DailyWeatherStats> GetByIntervalTime(DateTime initial, DateTime final);
    Task<DailyWeatherStats> GetLast();
    Task AddAsync(DailyWeatherStats dailyWeatherStats);
    Task SaveAsync();
}
