using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApplication.Common.Abstractions.Repositories;

public interface IMonthlyWeatherStatsRepository
{
    Task<MonthlyWeatherStats> GetById(DateTime id);
    Task<List<MonthlyWeatherStats>> GetByIntervalTimeAsync(DateTime initial, DateTime final);
    Task<MonthlyWeatherStats> GetFirstAsync();
    Task<MonthlyWeatherStats> GetLastAsync();
    Task AddAsync(MonthlyWeatherStats monthlyWeatherStats);
    Task AddRangeAsync(List<MonthlyWeatherStats> monthlyWeatherStats);
    Task BulkUpsertAsync(IEnumerable<MonthlyWeatherStats> monthlyWeatherStats);
    Task SaveAsync();
}
