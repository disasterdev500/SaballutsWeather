using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherRepositories.Abstractions;


namespace SaballutsWeatherApplication.Behaviors;

public class WeatherRecordService(IWeatherRecordsRepository weatherRecordRepository) : IWeatherRecordService
{
    private readonly IWeatherRecordsRepository _weatherRecordRepository = weatherRecordRepository;

    public async Task<WeatherRecord> GetByIDAsync(DateTime timestamp) => await _weatherRecordRepository.GetById(timestamp);

    public List<WeatherRecord> GetByDateRange(DateTime initial, DateTime final) => _weatherRecordRepository.GetByIntervalTime(initial, final);

    public async Task AddAsync(WeatherRecord weatherRecord) => await _weatherRecordRepository.AddAsync(weatherRecord);

    public async Task AddRangeAsync(List<WeatherRecord> weatherRecords) => await _weatherRecordRepository.AddRangeAsync(weatherRecords);
}