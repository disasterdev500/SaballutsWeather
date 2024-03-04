using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherPersistence.DbModels;
using SaballutsWeatherRepositories.Abstractions;
using System.Linq.Expressions;

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
        var records = await _context.DailyWeatherStats.OrderBy(d => d.Date).FirstAsync();
        return _mapper.Map<DailyWeatherStats>(records);
    }

    public async Task<DailyWeatherStats> GetLastAsync()
    {
        var records = await _context.DailyWeatherStats.OrderByDescending(d => d.Date).FirstAsync();
        return _mapper.Map<DailyWeatherStats>(records);
    }

    public async Task<List<DailyWeatherStats>> GetByIntervalTimeAsync(DateTime initial, DateTime final)
    {
        Expression<Func<DbDailyWeatherStats, bool>> filter = dbRecord => dbRecord.Date >= initial && dbRecord.Date < final;
        return await SearchAsync(filter);
    }

    private async Task<List<DailyWeatherStats>> SearchAsync(Expression<Func<DbDailyWeatherStats, bool>> filter)
            => _mapper.Map<List<DailyWeatherStats>>(await _context.DailyWeatherStats.Where(filter).ToListAsync());

    public async Task AddAsync(DailyWeatherStats dailyWeatherStats)
            => await _context.DailyWeatherStats.AddAsync(_mapper.Map<DbDailyWeatherStats>(dailyWeatherStats));

    public async Task SaveAsync()
            => await _context.SaveChangesAsync();
}