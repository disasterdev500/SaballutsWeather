using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherRepositories.Repositories;


namespace SaballutsWeatherApplication.Behaviors;

public class WeatherRecordGetter(IWeatherRecordsRepository weatherRecordRepository) : IWeatherRecordGetter
{
    private readonly IWeatherRecordsRepository _weatherRecordRepository = weatherRecordRepository;

    public async Task<WeatherRecord> GetByIDAsync(DateTime timestamp) => await _weatherRecordRepository.GetById(timestamp);
}