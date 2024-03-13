using AutoMapper;
using SaballutsWeatherLoader.Dtos;
using SaballutsWeatherDomain.Models;
using System.Globalization;

namespace SaballutsWeatherLoader.Utilities.Mappers;

public class CsvMappingProfile : Profile
{
    const string format = "yyyy-MM-dd HH:mm:ss";

    public CsvMappingProfile()
    {
        CreateMap<CsvWeatherRecord, WeatherRecord>().
            ForMember(db => db.Date, m => m.MapFrom(csv => ParseDateTime(csv.Timestamp, format)));
    }

    private DateTime ParseDateTime(string timestamp, string format)
    {
        if (DateTime.TryParseExact(timestamp, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDateTime))
        {
            return parsedDateTime;
        }

        // Handle parsing error, throw exception, log, or provide a default value.
        throw new ArgumentException($"Failed to parse timestamp: {timestamp} using format: {format}");
    }
}
