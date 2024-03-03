using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherRepositories.Abstractions;

public interface IYearlyWeatherStatsRepository
{
    Task<YearlyWeatherStats> GetById(DateTime id);
    List<YearlyWeatherStats> GetByIntervalTime(DateTime initial, DateTime final);
    Task AddAsync(YearlyWeatherStats yearlyWeatherStats);
    Task SaveAsync();
}
