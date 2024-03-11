using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherPersistence.DbModels;
using SaballutsWeatherApplication.Common.Abstractions.Repositories;
using System.Linq.Expressions;
//using System.Runtime.InteropServices;

namespace SaballutsWeatherRepositories.Repositories;

public class DailyWeatherStatsRepository(SaballutsWeatherContext context, IMapper mapper) : IDailyWeatherStatsRepository
{
    private readonly IMapper _mapper = mapper;
    private readonly SaballutsWeatherContext _context = context;

    public async Task<DailyWeatherStats> GetById(DateTime id)
    {
        var records = await _context.DailyWeatherStats.FindAsync(id);
        return _mapper.Map<DailyWeatherStats>(records);
    }

    public async Task<DailyWeatherStats> GetFirstAsync()
    {
        var records = await _context.DailyWeatherStats.OrderBy(d => d.Date).FirstOrDefaultAsync();
        return _mapper.Map<DailyWeatherStats>(records);
    }

    public async Task<DailyWeatherStats> GetLastAsync()
    {
        var records = await _context.DailyWeatherStats.OrderByDescending(d => d.Date).FirstOrDefaultAsync();
        if (records is null)
        {
            return null;
        }
        return _mapper.Map<DailyWeatherStats>(records);
    }

    public async Task<List<DailyWeatherStats>> GetByIntervalTimeAsync(DateTime initial, DateTime final)
    {
        Expression<Func<DbDailyWeatherStats, bool>> filter = dbRecord => dbRecord.Date >= initial && dbRecord.Date < final;
        return await SearchAsync(filter);
    }

    private async Task<List<DailyWeatherStats>> SearchAsync(Expression<Func<DbDailyWeatherStats, bool>> filter)
    {
        var records = await _context.DailyWeatherStats.Where(filter).ToListAsync();
        return (records is null) ? null : _mapper.Map<List<DailyWeatherStats>>(records);
    }

    public async Task AddAsync(DailyWeatherStats dailyWeatherStats)
    {
        var dbstats = _mapper.Map<DbDailyWeatherStats>(dailyWeatherStats);
        await _context.DailyWeatherStats.AddAsync(dbstats);
    }

    public async Task AddRangeAsync(List<DailyWeatherStats> dailyWeatherStats)
    {
        var dbstats = _mapper.Map<List<DbDailyWeatherStats>>(dailyWeatherStats);
        await _context.DailyWeatherStats.AddRangeAsync(dbstats);
    }

    public async Task SaveAsync()
            => await _context.SaveChangesAsync();
}