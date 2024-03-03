using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherRepositories.Abstractions;

namespace SaballutsWeatherApplication.Behaviors;

public class YearlyWeatherStatsService(IYearlyWeatherStatsRepository yearlyWeatherStatsRepository) : IYearlyWeatherStatsService
{
    private readonly IYearlyWeatherStatsRepository _yearlyWeatherStatsRepository = yearlyWeatherStatsRepository;

    public async Task<YearlyWeatherStats> GetByIDAsync(DateTime timestamp) => await _yearlyWeatherStatsRepository.GetById(timestamp);
}