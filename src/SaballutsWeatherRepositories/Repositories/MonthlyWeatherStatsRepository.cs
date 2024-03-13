using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherPersistence.DbModels;
using SaballutsWeatherApplication.Common.Abstractions.Repositories;
using System.Linq.Expressions;
using EFCore.BulkExtensions;

namespace SaballutsWeatherRepositories.Repositories;

public class MonthlyWeatherStatsRepository(SaballutsWeatherContext context, IMapper mapper) : IMonthlyWeatherStatsRepository
{
    private readonly IMapper _mapper = mapper;
    private readonly SaballutsWeatherContext _context = context;

    public async Task<MonthlyWeatherStats> GetById(DateTime id)
    {
        var records = await _context.MonthlyWeatherStats.FindAsync(id);
        return _mapper.Map<MonthlyWeatherStats>(records);
    }

    public async Task<List<MonthlyWeatherStats>> GetByIntervalTimeAsync(DateTime initial, DateTime final)
    {
        Expression<Func<DbMonthlyWeatherStats, bool>> filter = dbRecord => dbRecord.Date >= initial && dbRecord.Date < final;
        return await SearchAsync(filter);
    }

    public async Task<MonthlyWeatherStats> GetFirstAsync()
    {
        var records = await _context.MonthlyWeatherStats.OrderBy(d => d.Date).FirstOrDefaultAsync();
        return _mapper.Map<MonthlyWeatherStats>(records);
    }

    public async Task<MonthlyWeatherStats> GetLastAsync()
    {
        var records = await _context.MonthlyWeatherStats.OrderByDescending(d => d.Date).FirstOrDefaultAsync();
        if (records is null)
        {
            return null;
        }
        return _mapper.Map<MonthlyWeatherStats>(records);
    }

    private async Task<List<MonthlyWeatherStats>> SearchAsync(Expression<Func<DbMonthlyWeatherStats, bool>> filter)
            => _mapper.Map<List<MonthlyWeatherStats>>(await _context.MonthlyWeatherStats.Where(filter).ToListAsync());

    public async Task AddAsync(MonthlyWeatherStats monthlyWeatherStats)
            => await _context.MonthlyWeatherStats.AddAsync(_mapper.Map<DbMonthlyWeatherStats>(monthlyWeatherStats));

    public async Task AddRangeAsync(List<MonthlyWeatherStats> monthlyWeatherStats)
    {
        var dbstats = _mapper.Map<List<DbMonthlyWeatherStats>>(monthlyWeatherStats);
        await _context.MonthlyWeatherStats.AddRangeAsync(dbstats);
    }

    public async Task BulkUpsertAsync(IEnumerable<MonthlyWeatherStats> monthlyWeatherStats)
    {
        var dbWeatherRecords = _mapper.Map<IEnumerable<DbMonthlyWeatherStats>>(monthlyWeatherStats);
        await _context.BulkInsertOrUpdateAsync(dbWeatherRecords);
    }

    public async Task SaveAsync()
            => await _context.SaveChangesAsync();
}