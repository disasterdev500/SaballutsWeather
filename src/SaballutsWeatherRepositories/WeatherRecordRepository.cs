using AutoMapper;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherPersistance.DbModels;

namespace SaballutsWeatherRepositories.Repositories;

public class WeatherRecordsRepository(SaballutsWeatherContext context, IMapper mapper) : IWeatherRecordsRepository
{
    private readonly IMapper _mapper = mapper;
    private readonly SaballutsWeatherContext _context = context;

    public async Task<WeatherRecord> GetById(DateTime id)
    {
        var records = await _context.WeatherRecords.FindAsync(id);
        return _mapper.Map<WeatherRecord>(records);
    }
}