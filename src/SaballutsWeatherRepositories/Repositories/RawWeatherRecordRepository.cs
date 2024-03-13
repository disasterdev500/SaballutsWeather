using AutoMapper;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherPersistence.DbModels;
using SaballutsWeatherApplication.Common.Abstractions.Repositories;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;

namespace SaballutsWeatherRepositories.Repositories;

public class RawWeatherRecordsRepository(SaballutsWeatherContext context, IMapper mapper) : IRawWeatherRecordsRepository
{
    private readonly IMapper _mapper = mapper;
    private readonly SaballutsWeatherContext _context = context;

    public async Task<RawWeatherRecord> GetById(int id)
    {
        var records = await _context.RawWeatherRecords.FindAsync(id);
        return _mapper.Map<RawWeatherRecord>(records);
    }

    public async Task<List<RawWeatherRecord>> GetByIntervalTimeAsync(DateTime initial, DateTime final)
    {
        Expression<Func<DbRawWeatherRecord, bool>> filter = dbRecord => dbRecord.Date >= initial && dbRecord.Date < final;
        return await SearchAsync(filter);
    }

    public async Task<RawWeatherRecord> GetFirstAsync()
    {
        var records = await _context.RawWeatherRecords.OrderBy(d => d.Date).FirstOrDefaultAsync();
        return _mapper.Map<RawWeatherRecord>(records);
    }

    public async Task<RawWeatherRecord> GetLastAsync()
    {
        var records = await _context.RawWeatherRecords.OrderByDescending(d => d.Date).FirstOrDefaultAsync();
        return (records is null) ? null : _mapper.Map<RawWeatherRecord>(records);
    }

    private async Task<List<RawWeatherRecord>> SearchAsync(Expression<Func<DbRawWeatherRecord, bool>> filter)
            => _mapper.Map<List<RawWeatherRecord>>(await _context.RawWeatherRecords.Where(filter).ToListAsync());

    public async Task AddAsync(RawWeatherRecord rawWeatherRecord)
            => await _context.RawWeatherRecords.AddAsync(_mapper.Map<DbRawWeatherRecord>(rawWeatherRecord));

    public async Task AddRangeAsync(IEnumerable<RawWeatherRecord> rawWeatherRecords)
            => await _context.RawWeatherRecords.AddRangeAsync(_mapper.Map<IEnumerable<DbRawWeatherRecord>>(rawWeatherRecords));

    public async Task BulkUpsertAsync(IEnumerable<RawWeatherRecord> rawWeatherRecords)
    {
        var dbWeatherRecords = _mapper.Map<IEnumerable<DbRawWeatherRecord>>(rawWeatherRecords);
        await _context.BulkInsertOrUpdateAsync(dbWeatherRecords);
    }

    public async Task SaveAsync()
            => await _context.SaveChangesAsync();
}