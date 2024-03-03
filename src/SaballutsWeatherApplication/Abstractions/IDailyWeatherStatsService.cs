using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApplication.Abstractions;

public interface IDailyWeatherStatsService
{
    Task<DailyWeatherStats> GetByIDAsync(DateTime timestamp);
}
