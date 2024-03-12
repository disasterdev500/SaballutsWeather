using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherLoader.Application.Services;

public class WeatherRecordsLoader(IWeatherRecordService weatherRecordService) : IBatchTask<WeatherRecord>
{
    private readonly IWeatherRecordService _weatherRecordService = weatherRecordService;

    public async Task Execute(IEnumerable<WeatherRecord> elements)
     => await _weatherRecordService.AddRangeAsync(elements.ToList());
}