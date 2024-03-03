using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherRepositories.Abstractions;

public interface IWeeklyWeatherStatsRepository
{
    Task<WeeklyWeatherStats> GetById(DateTime id);
    List<WeeklyWeatherStats> GetByIntervalTime(DateTime initial, DateTime final);
    Task AddAsync(WeeklyWeatherStats weeklyWeatherStats);
    Task SaveAsync();
}
