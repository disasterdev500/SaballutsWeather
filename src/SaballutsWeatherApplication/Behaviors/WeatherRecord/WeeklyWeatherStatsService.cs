using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherRepositories.Abstractions;
using SaballutsWeatherDomain.Core;
using SaballutsWeatherCommon.Extensions;

namespace SaballutsWeatherApplication.Behaviors;

public class WeeklyWeatherStatsService(IWeeklyWeatherStatsRepository weeklyWeatherStatsRepository, IDailyWeatherStatsRepository dailyWeatherStatsRepository) : IWeeklyWeatherStatsService
{
    private readonly IWeeklyWeatherStatsRepository _weeklyWeatherStatsRepository = weeklyWeatherStatsRepository;
    private readonly IDailyWeatherStatsRepository _dailyWeatherStatsRepository = dailyWeatherStatsRepository;

    public async Task<WeeklyWeatherStats> GetByIDAsync(DateTime timestamp) => await _weeklyWeatherStatsRepository.GetById(timestamp);

    public async Task<Result<WeeklyWeatherStats>> CreateAsync(DateTime date)
    {
        var firstDayOfWeek = date.GetFirstDayOfWeek();
        var lastDayOfWeek = firstDayOfWeek.AddDays(7);

        var dailyStats = await _dailyWeatherStatsRepository.GetByIntervalTimeAsync(firstDayOfWeek, lastDayOfWeek);
        if (dailyStats is null || dailyStats.Count == 0)
        {
            return Result.Fail<WeeklyWeatherStats>("There are no daily weather stats for the specified dates");
        }

        WeeklyWeatherStats weeklyWeatherStats = new(dailyStats);
        await _weeklyWeatherStatsRepository.AddAsync(weeklyWeatherStats);
        await _weeklyWeatherStatsRepository.SaveAsync();

        return Result.Ok(weeklyWeatherStats);
    }

    public async Task<Result> GenerateWeeklyWeatherStatsSinceLastAsync()
    {
        DateTime initialDate;
        var stats = await _weeklyWeatherStatsRepository.GetLastAsync();
        if (stats is null)
        {
            var dailyStats = await _dailyWeatherStatsRepository.GetFirstAsync();
            if (dailyStats is null)
            {
                return Result.Fail("First daily weather stats not found");
            }
            initialDate = dailyStats.Date.Date;
        }
        else
        {
            initialDate = stats.Date.AddDays(7);
        }

        var lastDailyStats = await _dailyWeatherStatsRepository.GetLastAsync();
        if (lastDailyStats is null)
        {
            return Result.Fail<WeeklyWeatherStats>("Last daily weather stats not found");
        }

        var finalDate = lastDailyStats.Date.Date;

        while (initialDate < finalDate)
        {
            var result = await CreateAsync(initialDate);
            if (result.IsFailure)
            {
                //TODO: What to do in this case? Error? Exception? Group errors?
                System.Console.WriteLine($"{initialDate}: Weekly Weather Stats not created: {result.Error}");
            }

            initialDate = initialDate.AddDays(7);
        }

        return Result.Ok();
    }
}