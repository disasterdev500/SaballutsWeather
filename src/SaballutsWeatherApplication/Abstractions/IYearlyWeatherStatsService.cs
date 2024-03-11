using SaballutsWeatherDomain.Models;
using SaballutsWeatherDomain.Core;

namespace SaballutsWeatherApplication.Abstractions;

public interface IYearlyWeatherStatsService
{
    Task<YearlyWeatherStats> GetByIDAsync(DateTime timestamp);
    Task<Result<YearlyWeatherStats>> CreateAsync(DateTime date);
    Task<Result> GenerateYearlyWeatherStatsSinceLastAsync();
}
