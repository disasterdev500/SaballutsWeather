using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherRepositories.Abstractions;


namespace SaballutsWeatherApplication.Behaviors;

public class DailyWeatherStatsService(IDailyWeatherStatsRepository dailyWeatherStatsRepository) : IDailyWeatherStatsService
{
    private readonly IDailyWeatherStatsRepository _dailyWeatherStatsRepository = dailyWeatherStatsRepository;

    public async Task<DailyWeatherStats> GetByIDAsync(DateTime timestamp) => await _dailyWeatherStatsRepository.GetById(timestamp);
}