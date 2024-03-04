using SaballutsWeatherDomain.Models;
using SaballutsWeatherDomain.Core;

namespace SaballutsWeatherApplication.Abstractions;

public interface IDailyWeatherStatsService
{
    Task<DailyWeatherStats> GetByIDAsync(DateTime timestamp);
    Task<Result<DailyWeatherStats>> CreateAsync(DateTime date);
    Task<Result> GenerateDailyWeatherStatsSinceLastAsync();
}
