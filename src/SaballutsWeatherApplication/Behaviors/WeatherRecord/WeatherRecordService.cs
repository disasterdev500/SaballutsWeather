using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherRepositories.Abstractions;


namespace SaballutsWeatherApplication.Behaviors;

public class WeatherRecordService(IWeatherRecordsRepository weatherRecordRepository) : IWeatherRecordService
{
    private readonly IWeatherRecordsRepository _weatherRecordRepository = weatherRecordRepository;

    public async Task<WeatherRecord> GetByIDAsync(DateTime timestamp) => await _weatherRecordRepository.GetById(timestamp);

    public async Task<List<WeatherRecord>> GetByDateRangeAsync(DateTime initial, DateTime final) => await _weatherRecordRepository.GetByIntervalTimeAsync(initial, final);

    public async Task AddAsync(WeatherRecord weatherRecord)
    {
        var record = await _weatherRecordRepository.GetById(weatherRecord.Date);
        if (record is not null)
        {
            return;
        }
        await _weatherRecordRepository.AddAsync(weatherRecord);
        await _weatherRecordRepository.SaveAsync();
    }

    public async Task AddRangeAsync(List<WeatherRecord> weatherRecords)
    {
        await _weatherRecordRepository.AddRangeAsync(weatherRecords);
        await _weatherRecordRepository.SaveAsync();
    }
}