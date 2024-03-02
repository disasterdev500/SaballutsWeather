using AutoMapper;
using SaballutsWeatherPersistence.DbModels;
using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherUtilities.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<WeatherRecord, DbWeatherRecord>();
        CreateMap<DbWeatherRecord, WeatherRecord>();

        CreateMap<DailyWeatherStats, DbDailyWeatherStats>();
        CreateMap<DbDailyWeatherStats, DailyWeatherStats>();
    }
}