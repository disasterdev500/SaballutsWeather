using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherApplication.Common.Abstractions.Repositories;
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
        if (date.Date >= DateTime.UtcNow.GetFirstDayOfWeek())
        {
            throw new ArgumentException();
        }

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
            initialDate = dailyStats.Id.Date;
        }
        else
        {
            initialDate = stats.Id.AddDays(7);
        }

        var lastDailyStats = await _dailyWeatherStatsRepository.GetLastAsync();
        if (lastDailyStats is null)
        {
            return Result.Fail<WeeklyWeatherStats>("Last daily weather stats not found");
        }

        var finalDate = lastDailyStats.Id.GetFirstDayOfWeek();

        List<WeeklyWeatherStats> weeklyWeatherStatsList = new();
        for (; initialDate < finalDate; initialDate = initialDate.AddDays(7))
        {
            var weeklyWeatherStats = await GenerateWeeklyWeatherStatAsync(initialDate);
            if (weeklyWeatherStats is null)
            {
                continue;
            }
            weeklyWeatherStatsList.Add(weeklyWeatherStats);
        }

        await _weeklyWeatherStatsRepository.AddRangeAsync(weeklyWeatherStatsList);
        await _weeklyWeatherStatsRepository.SaveAsync();

        return Result.Ok();
    }

    private async Task<WeeklyWeatherStats> GenerateWeeklyWeatherStatAsync(DateTime date)
    {
        if (date.Date >= DateTime.UtcNow.GetFirstDayOfWeek())
        {
            throw new ArgumentException();
        }

        var firstDayOfWeek = date.GetFirstDayOfWeek();
        var lastDayOfWeek = firstDayOfWeek.AddDays(7);

        var dailyStats = await _dailyWeatherStatsRepository.GetByIntervalTimeAsync(firstDayOfWeek, lastDayOfWeek);
        if (dailyStats is null || dailyStats.Count == 0)
        {
            return null;
        }

        WeeklyWeatherStats weeklyWeatherStats = new(dailyStats);

        return weeklyWeatherStats;
    }
}