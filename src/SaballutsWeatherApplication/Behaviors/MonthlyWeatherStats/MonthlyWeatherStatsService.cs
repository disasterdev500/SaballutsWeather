using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherDomain.Core;
using SaballutsWeatherApplication.Common.Abstractions.Repositories;
using SaballutsWeatherCommon.Extensions;

namespace SaballutsWeatherApplication.Behaviors;

public class MonthlyWeatherStatsService(IMonthlyWeatherStatsRepository monthlyWeatherStatsRepository, IDailyWeatherStatsRepository dailyWeatherStatsRepository) : IMonthlyWeatherStatsService
{
    private readonly IMonthlyWeatherStatsRepository _monthlyWeatherStatsRepository = monthlyWeatherStatsRepository;
    private readonly IDailyWeatherStatsRepository _dailyWeatherStatsRepository = dailyWeatherStatsRepository;

    public async Task<MonthlyWeatherStats> GetByIDAsync(DateTime timestamp) => await _monthlyWeatherStatsRepository.GetById(timestamp);

    public async Task<Result<MonthlyWeatherStats>> CreateAsync(DateTime date)
    {
        if (date.Date >= DateTime.UtcNow.GetFirstDayOfMonth())
        {
            throw new ArgumentException();
        }

        var firstDayOfMonth = date.GetFirstDayOfMonth();

        var dailyStats = await _dailyWeatherStatsRepository.GetByIntervalTimeAsync(firstDayOfMonth, firstDayOfMonth.AddMonths(1));
        if (dailyStats is null || dailyStats.Count == 0)
        {
            return Result.Fail<MonthlyWeatherStats>("There are no daily weather stats for the specified dates");
        }

        MonthlyWeatherStats monthlyWeatherStats = new(dailyStats);
        await _monthlyWeatherStatsRepository.AddAsync(monthlyWeatherStats);
        await _monthlyWeatherStatsRepository.SaveAsync();

        return Result.Ok(monthlyWeatherStats);
    }

    public async Task<Result> GenerateMonthlyWeatherStatsSinceLastAsync()
    {
        DateTime initialDate;
        var stats = await _monthlyWeatherStatsRepository.GetLastAsync();
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
            initialDate = stats.Id.AddMonths(1);
        }

        var lastDailyStats = await _dailyWeatherStatsRepository.GetLastAsync();
        if (lastDailyStats is null)
        {
            return Result.Fail<WeeklyWeatherStats>("Last daily weather stats not found");
        }

        var finalDate = lastDailyStats.Id.GetFirstDayOfMonth();

        List<MonthlyWeatherStats> monthlyWeatherStatsList = new();
        for (; initialDate < finalDate; initialDate = initialDate.AddMonths(1))
        {
            var monthlyWeatherStats = await GenerateMonthlyWeatherStatAsync(initialDate);
            if (monthlyWeatherStats is null)
            {
                continue;
            }
            monthlyWeatherStatsList.Add(monthlyWeatherStats);
        }

        await _monthlyWeatherStatsRepository.AddRangeAsync(monthlyWeatherStatsList);
        await _monthlyWeatherStatsRepository.SaveAsync();


        return Result.Ok();
    }


    private async Task<MonthlyWeatherStats> GenerateMonthlyWeatherStatAsync(DateTime date)
    {
        if (date.Date >= DateTime.UtcNow.GetFirstDayOfMonth())
        {
            throw new ArgumentException();
        }

        var firstDayOfMonth = date.GetFirstDayOfMonth();

        var dailyStats = await _dailyWeatherStatsRepository.GetByIntervalTimeAsync(firstDayOfMonth, firstDayOfMonth.AddMonths(1));
        if (dailyStats is null || dailyStats.Count == 0)
        {
            return null;
        }

        MonthlyWeatherStats monthlyWeatherStats = new(dailyStats);

        return monthlyWeatherStats;
    }
}