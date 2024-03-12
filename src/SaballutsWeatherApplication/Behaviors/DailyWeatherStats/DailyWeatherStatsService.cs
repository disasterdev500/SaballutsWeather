using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherDomain.Core;
using SaballutsWeatherApplication.Common.Abstractions.Repositories;

namespace SaballutsWeatherApplication.Behaviors;

public class DailyWeatherStatsService(IDailyWeatherStatsRepository dailyWeatherStatsRepository, IWeatherRecordsRepository weatherRecordsRepository) : IDailyWeatherStatsService
{
    private readonly IDailyWeatherStatsRepository _dailyWeatherStatsRepository = dailyWeatherStatsRepository;
    private readonly IWeatherRecordsRepository _weatherRecordsRepository = weatherRecordsRepository;

    public async Task<DailyWeatherStats> GetByIDAsync(DateTime timestamp) => await _dailyWeatherStatsRepository.GetById(timestamp);

    public async Task<Result<DailyWeatherStats>> CreateAsync(DateTime date)
    {
        if (date.Date >= DateTime.UtcNow.Date)
        {
            throw new ArgumentException();
        }

        var initialDate = date.Date;

        var stats = await _dailyWeatherStatsRepository.GetById(date.Date);
        if (stats is not null)
        {
            return Result.Ok(stats);
        }

        var records = await _weatherRecordsRepository.GetByIntervalTimeAsync(initialDate, initialDate.AddDays(1));
        if (records is null)
        {
            return Result.Fail<DailyWeatherStats>("There are no records for the specified dates");
        }

        DailyWeatherStats dailyWeatherStats = new(records);
        await _dailyWeatherStatsRepository.AddAsync(dailyWeatherStats);
        await _dailyWeatherStatsRepository.SaveAsync();

        return Result.Ok(stats);
    }

    public async Task<Result> GenerateDailyWeatherStatsSinceLastAsync()
    {
        DateTime initialDate;
        var stats = await _dailyWeatherStatsRepository.GetLastAsync();
        if (stats is null || stats.Id.Equals(default))
        {
            var firstRecord = await _weatherRecordsRepository.GetFirstAsync();
            if (firstRecord is null)
            {
                return Result.Fail("First record not found");
            }
            initialDate = firstRecord.Date.Date;
        }
        else
        {
            initialDate = stats.Id.Date.AddDays(1);
        }

        var lastRecord = await _weatherRecordsRepository.GetLastAsync();
        if (lastRecord is null)
        {
            return Result.Fail<DailyWeatherStats>("Last record not found");
        }

        var finalDate = lastRecord.Date.Date;

        List<DailyWeatherStats> dailyWeatherStatsList = new();
        for (; initialDate < finalDate; initialDate = initialDate.AddDays(1))
        {
            var dailyWeatherStats = await GenerateDailyWeatherStatAsync(initialDate);
            if (dailyWeatherStats is null)
            {
                System.Console.WriteLine($"dailyWeatherStats: {dailyWeatherStats}");
                continue;
            }
            dailyWeatherStatsList.Add(dailyWeatherStats);
        }

        await _dailyWeatherStatsRepository.AddRangeAsync(dailyWeatherStatsList);
        await _dailyWeatherStatsRepository.SaveAsync();

        return Result.Ok();
    }

    private async Task<DailyWeatherStats> GenerateDailyWeatherStatAsync(DateTime date)
    {
        if (date.Date >= DateTime.UtcNow.Date)
        {
            throw new ArgumentException();
        }

        var initialDate = date.Date;

        var stats = await _dailyWeatherStatsRepository.GetById(date.Date);
        if (stats is not null)
        {
            return null;
        }

        var records = await _weatherRecordsRepository.GetByIntervalTimeAsync(initialDate, initialDate.AddDays(1));
        if (records is null)
        {
            return null;
        }

        DailyWeatherStats dailyWeatherStats = new(records);

        return dailyWeatherStats;
    }
}