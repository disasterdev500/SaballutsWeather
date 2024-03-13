using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApplication.Abstractions;

public interface IRawWeatherRecordService
{
    Task<RawWeatherRecord> GetByIDAsync(int id);
    Task<List<RawWeatherRecord>> GetByDateRangeAsync(DateTime initial, DateTime final);
    Task AddAsync(RawWeatherRecord weatherRecord);
    Task AddRangeAsync(List<RawWeatherRecord> weatherRecords);
}