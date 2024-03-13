using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApplication.Common.Abstractions.Repositories;

public interface IRawWeatherRecordsRepository
{
    Task<RawWeatherRecord> GetById(int id);
    Task<List<RawWeatherRecord>> GetByIntervalTimeAsync(DateTime initial, DateTime final);
    Task<RawWeatherRecord> GetLastAsync();
    Task<RawWeatherRecord> GetFirstAsync();
    Task AddAsync(RawWeatherRecord weatherRecord);
    Task AddRangeAsync(IEnumerable<RawWeatherRecord> weatherRecords);
    Task BulkUpsertAsync(IEnumerable<RawWeatherRecord> weatherRecords);
    Task SaveAsync();
}
