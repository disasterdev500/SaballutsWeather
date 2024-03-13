using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApplication.Common.Abstractions.Repositories;

public interface IWeeklyWeatherStatsRepository
{
    Task<WeeklyWeatherStats> GetById(DateTime id);
    Task<List<WeeklyWeatherStats>> GetByIntervalTime(DateTime initial, DateTime final);
    Task<WeeklyWeatherStats> GetFirstAsync();
    Task<WeeklyWeatherStats> GetLastAsync();
    Task AddAsync(WeeklyWeatherStats weeklyWeatherStats);
    Task AddRangeAsync(List<WeeklyWeatherStats> weeklyWeatherStats);
    Task BulkUpsertAsync(IEnumerable<WeeklyWeatherStats> weeklyWeatherStats);
    Task SaveAsync();
}
