using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApplication.Abstractions;

public interface IMonthlyWeatherStatsService
{
    Task<MonthlyWeatherStats> GetByIDAsync(DateTime timestamp);
}
