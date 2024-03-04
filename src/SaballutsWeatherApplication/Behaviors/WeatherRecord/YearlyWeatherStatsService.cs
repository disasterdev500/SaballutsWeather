using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherRepositories.Abstractions;
using SaballutsWeatherDomain.Core;
using SaballutsWeatherCommon.Extensions;

namespace SaballutsWeatherApplication.Behaviors;

public class YearlyWeatherStatsService(IYearlyWeatherStatsRepository yearlyWeatherStatsRepository, IMonthlyWeatherStatsRepository monthlyWeatherStatsRepository) : IYearlyWeatherStatsService
{
    private readonly IYearlyWeatherStatsRepository _yearlyWeatherStatsRepository = yearlyWeatherStatsRepository;
    private readonly IMonthlyWeatherStatsRepository _monthlyWeatherStatsRepository = monthlyWeatherStatsRepository;

    public async Task<YearlyWeatherStats> GetByIDAsync(DateTime timestamp) => await _yearlyWeatherStatsRepository.GetById(timestamp);

    public async Task<Result<YearlyWeatherStats>> CreateAsync(DateTime date)
    {
        var firstDayOfYear = date.GetFirstDayOfYear();

        var monthlylyStats = await _monthlyWeatherStatsRepository.GetByIntervalTimeAsync(firstDayOfYear, firstDayOfYear.AddYears(1));
        if (monthlylyStats is null || monthlylyStats.Count == 0)
        {
            return Result.Fail<YearlyWeatherStats>("There are no monthly weather stats for the specified dates");
        }

        YearlyWeatherStats yearlyWeatherStats = new(monthlylyStats);
        await _yearlyWeatherStatsRepository.AddAsync(yearlyWeatherStats);
        await _yearlyWeatherStatsRepository.SaveAsync();

        return Result.Ok(yearlyWeatherStats);
    }

    public async Task<Result> GenerateMonthlyWeatherStatsSinceLastAsync()
    {
        DateTime initialDate;
        var stats = await _yearlyWeatherStatsRepository.GetLastAsync();
        if (stats is null)
        {
            var monthlyStats = await _monthlyWeatherStatsRepository.GetFirstAsync();
            if (monthlyStats is null)
            {
                return Result.Fail("First monthly weather stats not found");
            }
            initialDate = monthlyStats.Date.Date;
        }
        else
        {
            initialDate = stats.Date.AddYears(1);
        }

        var lastMonthlyStats = await _monthlyWeatherStatsRepository.GetLastAsync();
        if (lastMonthlyStats is null)
        {
            return Result.Fail<WeeklyWeatherStats>("Last monthly weather stats not found");
        }

        var finalDate = lastMonthlyStats.Date.Date;

        while (initialDate < finalDate)
        {
            var result = await CreateAsync(initialDate);
            if (result.IsFailure)
            {
                //TODO: What to do in this case? Error? Exception? Group errors?
                System.Console.WriteLine($"{initialDate}: Yearly Weather Stats not created: {result.Error}");
            }

            initialDate = initialDate.AddYears(1);
        }

        return Result.Ok();
    }
}