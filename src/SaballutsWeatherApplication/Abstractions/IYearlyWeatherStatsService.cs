using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApplication.Abstractions;

public interface IYearlyWeatherStatsService
{
    Task<YearlyWeatherStats> GetByIDAsync(DateTime timestamp);
}
