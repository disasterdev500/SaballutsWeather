using SaballutsWeatherDomain.Models;
using SaballutsWeatherDomain.Core;

namespace SaballutsWeatherApplication.Abstractions;

public interface IWeeklyWeatherStatsService
{
    Task<WeeklyWeatherStats> GetByIDAsync(DateTime timestamp);
    Task<Result<WeeklyWeatherStats>> CreateAsync(DateTime date);
    Task<Result> GenerateWeeklyWeatherStatsSinceLastAsync();
}
