using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherRepositories.Abstractions;

public interface IWeeklyWeatherStatsRepository
{
    Task<WeeklyWeatherStats> GetById(DateTime id);
    Task<List<WeeklyWeatherStats>> GetByIntervalTime(DateTime initial, DateTime final);
    Task<WeeklyWeatherStats> GetFirstAsync();
    Task<WeeklyWeatherStats> GetLastAsync();
    Task AddAsync(WeeklyWeatherStats weeklyWeatherStats);
    Task SaveAsync();
}
