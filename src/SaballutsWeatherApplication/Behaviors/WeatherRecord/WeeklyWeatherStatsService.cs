using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherRepositories.Abstractions;

namespace SaballutsWeatherApplication.Behaviors;

public class WeeklyWeatherStatsService(IWeeklyWeatherStatsRepository weeklyWeatherStatsRepository) : IWeeklyWeatherStatsService
{
    private readonly IWeeklyWeatherStatsRepository _weeklyWeatherStatsRepository = weeklyWeatherStatsRepository;

    public async Task<WeeklyWeatherStats> GetByIDAsync(DateTime timestamp) => await _weeklyWeatherStatsRepository.GetById(timestamp);
}