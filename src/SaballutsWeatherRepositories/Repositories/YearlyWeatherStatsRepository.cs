using AutoMapper;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherPersistence.DbModels;
using SaballutsWeatherApplication.Common.Abstractions.Repositories;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;

namespace SaballutsWeatherRepositories.Repositories;

public class YearlyWeatherStatsRepository(SaballutsWeatherContext context, IMapper mapper) : IYearlyWeatherStatsRepository
{
    private readonly IMapper _mapper = mapper;
    private readonly SaballutsWeatherContext _context = context;

    public async Task<YearlyWeatherStats> GetById(DateTime id)
    {
        var records = await _context.YearlyWeatherStats.FindAsync(id);
        return _mapper.Map<YearlyWeatherStats>(records);
    }

    public async Task<List<YearlyWeatherStats>> GetByIntervalTimeAsync(DateTime initial, DateTime final)
    {
        Expression<Func<DbYearlyWeatherStats, bool>> filter = dbRecord => dbRecord.Date >= initial && dbRecord.Date < final;
        return await SearchAsync(filter);
    }

    public async Task<YearlyWeatherStats> GetLastAsync()
    {
        var records = await _context.YearlyWeatherStats.OrderByDescending(d => d.Date).FirstOrDefaultAsync();
        return (records is null) ? null : _mapper.Map<YearlyWeatherStats>(records);
    }

    private async Task<List<YearlyWeatherStats>> SearchAsync(Expression<Func<DbYearlyWeatherStats, bool>> filter)
            => _mapper.Map<List<YearlyWeatherStats>>(await _context.YearlyWeatherStats.Where(filter).ToListAsync());

    public async Task AddAsync(YearlyWeatherStats yearlyWeatherStats)
            => await _context.YearlyWeatherStats.AddAsync(_mapper.Map<DbYearlyWeatherStats>(yearlyWeatherStats));

    public async Task AddRangeAsync(List<YearlyWeatherStats> yearlyWeatherStats)
    {
        var dbstats = _mapper.Map<List<DbYearlyWeatherStats>>(yearlyWeatherStats);
        await _context.YearlyWeatherStats.AddRangeAsync(dbstats);
    }

    public async Task BulkUpsertAsync(IEnumerable<YearlyWeatherStats> yearlyWeatherStats)
    {
        var dbWeatherRecords = _mapper.Map<IEnumerable<DbYearlyWeatherStats>>(yearlyWeatherStats);
        await _context.BulkInsertOrUpdateAsync(dbWeatherRecords);
    }

    public async Task SaveAsync()
            => await _context.SaveChangesAsync();
}