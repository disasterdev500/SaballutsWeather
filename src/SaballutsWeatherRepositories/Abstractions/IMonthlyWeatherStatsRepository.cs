using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherRepositories.Abstractions;

public interface IMonthlyWeatherStatsRepository
{
    Task<MonthlyWeatherStats> GetById(DateTime id);
    Task<List<MonthlyWeatherStats>> GetByIntervalTimeAsync(DateTime initial, DateTime final);
    Task<MonthlyWeatherStats> GetFirstAsync();
    Task<MonthlyWeatherStats> GetLastAsync();
    Task AddAsync(MonthlyWeatherStats monthlyWeatherStats);
    Task SaveAsync();
}
