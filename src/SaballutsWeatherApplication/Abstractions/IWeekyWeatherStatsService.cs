using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApplication.Abstractions;

public interface IWeeklyWeatherStatsService
{
    Task<WeeklyWeatherStats> GetByIDAsync(DateTime timestamp);
}
