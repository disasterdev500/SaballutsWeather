using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherRepositories.Abstractions;

public interface IMonthlyWeatherStatsRepository
{
    Task<MonthlyWeatherStats> GetById(DateTime id);
    List<MonthlyWeatherStats> GetByIntervalTime(DateTime initial, DateTime final);
    Task AddAsync(MonthlyWeatherStats monthlyWeatherStats);
    Task SaveAsync();
}
