using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherRepositories.Abstractions;

public interface IYearlyWeatherStatsRepository
{
    Task<YearlyWeatherStats> GetById(DateTime id);
    Task<List<YearlyWeatherStats>> GetByIntervalTimeAsync(DateTime initial, DateTime final);
    Task<YearlyWeatherStats> GetLastAsync();
    Task AddAsync(YearlyWeatherStats yearlyWeatherStats);
    Task SaveAsync();
}
