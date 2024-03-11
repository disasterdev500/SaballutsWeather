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

        CreateMap<DailyWeatherStats, DbDailyWeatherStats>().
            ForMember(db => db.Date, m => m.MapFrom(m => m.Id));
        CreateMap<DbDailyWeatherStats, DailyWeatherStats>().
            ForMember(db => db.Id, m => m.MapFrom(m => m.Date));

        CreateMap<WeeklyWeatherStats, DbWeeklyWeatherStats>().
            ForMember(db => db.Date, m => m.MapFrom(m => m.Id));
        CreateMap<DbWeeklyWeatherStats, WeeklyWeatherStats>().
            ForMember(db => db.Id, m => m.MapFrom(m => m.Date));

        CreateMap<MonthlyWeatherStats, DbMonthlyWeatherStats>().
            ForMember(db => db.Date, m => m.MapFrom(m => m.Id));
        CreateMap<DbMonthlyWeatherStats, MonthlyWeatherStats>().
            ForMember(db => db.Id, m => m.MapFrom(m => m.Date));

        CreateMap<YearlyWeatherStats, DbYearlyWeatherStats>().
            ForMember(db => db.Date, m => m.MapFrom(m => m.Id));
        CreateMap<DbYearlyWeatherStats, YearlyWeatherStats>().
            ForMember(db => db.Id, m => m.MapFrom(m => m.Date));
    }
}