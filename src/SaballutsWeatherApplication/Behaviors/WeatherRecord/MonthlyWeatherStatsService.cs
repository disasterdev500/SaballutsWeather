using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherRepositories.Abstractions;

namespace SaballutsWeatherApplication.Behaviors;

public class MonthlyWeatherStatsService(IMonthlyWeatherStatsRepository monthlyWeatherStatsRepository) : IMonthlyWeatherStatsService
{
    private readonly IMonthlyWeatherStatsRepository _monthlyWeatherStatsRepository = monthlyWeatherStatsRepository;

    public async Task<MonthlyWeatherStats> GetByIDAsync(DateTime timestamp) => await _monthlyWeatherStatsRepository.GetById(timestamp);
}