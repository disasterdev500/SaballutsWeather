using AutoMapper;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherPersistence.DbModels;
using SaballutsWeatherRepositories.Abstractions;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

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

    public List<WeatherRecord> GetByIntervalTime(DateTime initial, DateTime final)
    {
        Expression<Func<DbWeatherRecord, bool>> filter = dbRecord => dbRecord.Date >= initial && dbRecord.Date < final;
        return Search(filter);
    }

    public async Task<WeatherRecord> GetFirstAsync()
    {
        var records = await _context.WeatherRecords.OrderBy(d => d.Date).FirstAsync();
        return _mapper.Map<WeatherRecord>(records);
    }

    public async Task<WeatherRecord> GetLastAsync()
    {
        var records = await _context.WeatherRecords.OrderByDescending(d => d.Date).FirstAsync();
        return _mapper.Map<WeatherRecord>(records);
    }

    private List<WeatherRecord> Search(Expression<Func<DbWeatherRecord, bool>> filter)
            => _mapper.Map<List<WeatherRecord>>(_context.WeatherRecords.Where(filter).ToList());

    public async Task AddAsync(WeatherRecord weatherRecord)
            => await _context.WeatherRecords.AddAsync(_mapper.Map<DbWeatherRecord>(weatherRecord));

    public async Task AddRangeAsync(IEnumerable<WeatherRecord> weatherRecords)
            => await _context.WeatherRecords.AddRangeAsync(_mapper.Map<IEnumerable<DbWeatherRecord>>(weatherRecords));

    public async Task SaveAsync()
            => await _context.SaveChangesAsync();
}