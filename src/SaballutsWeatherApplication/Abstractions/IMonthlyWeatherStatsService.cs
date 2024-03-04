using SaballutsWeatherDomain.Models;
using SaballutsWeatherDomain.Core;

namespace SaballutsWeatherApplication.Abstractions;

public interface IMonthlyWeatherStatsService
{
    Task<MonthlyWeatherStats> GetByIDAsync(DateTime timestamp);
    Task<Result<MonthlyWeatherStats>> CreateAsync(DateTime date);
    Task<Result> GenerateMonthlyWeatherStatsSinceLastAsync();
}
