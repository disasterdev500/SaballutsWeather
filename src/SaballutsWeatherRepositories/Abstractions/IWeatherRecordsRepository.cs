using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherRepositories.Abstractions;

public interface IWeatherRecordsRepository
{
    Task<WeatherRecord> GetById(DateTime id);
}
