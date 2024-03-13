using AutoMapper;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherPersistence.DbModels;
using SaballutsWeatherApplication.Common.Abstractions.Repositories;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;

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

    public async Task<List<WeatherRecord>> GetByIntervalTimeAsync(DateTime initial, DateTime final)
    {
        Expression<Func<DbWeatherRecord, bool>> filter = dbRecord => dbRecord.Date >= initial && dbRecord.Date < final;
        return await SearchAsync(filter);
    }

    public async Task<WeatherRecord> GetFirstAsync()
    {
        var records = await _context.WeatherRecords.OrderBy(d => d.Date).FirstOrDefaultAsync();
        return _mapper.Map<WeatherRecord>(records);
    }

    public async Task<WeatherRecord> GetLastAsync()
    {
        var records = await _context.WeatherRecords.OrderByDescending(d => d.Date).FirstOrDefaultAsync();
        return (records is null) ? null : _mapper.Map<WeatherRecord>(records);
    }

    private async Task<List<WeatherRecord>> SearchAsync(Expression<Func<DbWeatherRecord, bool>> filter)
            => _mapper.Map<List<WeatherRecord>>(await _context.WeatherRecords.Where(filter).ToListAsync());

    public async Task AddAsync(WeatherRecord weatherRecord)
            => await _context.WeatherRecords.AddAsync(_mapper.Map<DbWeatherRecord>(weatherRecord));

    public async Task AddRangeAsync(IEnumerable<WeatherRecord> weatherRecords)
            => await _context.WeatherRecords.AddRangeAsync(_mapper.Map<IEnumerable<DbWeatherRecord>>(weatherRecords));

    public async Task BulkUpsertAsync(IEnumerable<WeatherRecord> weatherRecords)
    {
        var dbWeatherRecords = _mapper.Map<IEnumerable<DbWeatherRecord>>(weatherRecords);
        await _context.BulkInsertOrUpdateAsync(dbWeatherRecords);
    }

    public async Task SaveAsync()
            => await _context.SaveChangesAsync();
}