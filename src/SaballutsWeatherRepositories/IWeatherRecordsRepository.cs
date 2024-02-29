using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherPersistance.Repositories;

public interface IWeatherRecordsRepository
{
    Task<WeatherRecord> GetById(DateTime id);
}
