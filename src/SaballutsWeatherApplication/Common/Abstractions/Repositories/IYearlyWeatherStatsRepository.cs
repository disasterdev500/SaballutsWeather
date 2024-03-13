using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApplication.Common.Abstractions.Repositories;

public interface IYearlyWeatherStatsRepository
{
    Task<YearlyWeatherStats> GetById(DateTime id);
    Task<List<YearlyWeatherStats>> GetByIntervalTimeAsync(DateTime initial, DateTime final);
    Task<YearlyWeatherStats> GetLastAsync();
    Task AddAsync(YearlyWeatherStats yearlyWeatherStats);
    Task AddRangeAsync(List<YearlyWeatherStats> yearlyWeatherStats);
    Task BulkUpsertAsync(IEnumerable<YearlyWeatherStats> yearlyWeatherStats);
    Task SaveAsync();
}
