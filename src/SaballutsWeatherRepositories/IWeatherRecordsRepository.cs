using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherRepositories.Repositories;

public interface IWeatherRecordsRepository
{
    Task<WeatherRecord> GetById(DateTime id);
}
