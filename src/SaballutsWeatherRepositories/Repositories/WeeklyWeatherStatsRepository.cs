using AutoMapper;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherPersistence.DbModels;
using SaballutsWeatherApplication.Common.Abstractions.Repositories;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SaballutsWeatherRepositories.Repositories;

public class WeeklyWeatherStatsRepository(SaballutsWeatherContext context, IMapper mapper) : IWeeklyWeatherStatsRepository
{
    private readonly IMapper _mapper = mapper;
    private readonly SaballutsWeatherContext _context = context;

    public async Task<WeeklyWeatherStats> GetById(DateTime id)
    {
        var records = await _context.WeeklyWeatherStats.FindAsync(id);
        return _mapper.Map<WeeklyWeatherStats>(records);
    }

    public async Task<List<WeeklyWeatherStats>> GetByIntervalTime(DateTime initial, DateTime final)
    {
        Expression<Func<DbWeeklyWeatherStats, bool>> filter = dbRecord => dbRecord.Date >= initial && dbRecord.Date < final;
        return await SearchAsync(filter);
    }

    public async Task<WeeklyWeatherStats> GetFirstAsync()
    {
        var records = await _context.WeeklyWeatherStats.OrderBy(d => d.Date).FirstOrDefaultAsync();
        return _mapper.Map<WeeklyWeatherStats>(records);
    }

    public async Task<WeeklyWeatherStats> GetLastAsync()
    {
        var records = await _context.WeeklyWeatherStats.OrderByDescending(d => d.Date).FirstOrDefaultAsync();
        return (records is null) ? null : _mapper.Map<WeeklyWeatherStats>(records);
    }

    private async Task<List<WeeklyWeatherStats>> SearchAsync(Expression<Func<DbWeeklyWeatherStats, bool>> filter)
            => _mapper.Map<List<WeeklyWeatherStats>>(await _context.WeeklyWeatherStats.Where(filter).ToListAsync());

    public async Task AddAsync(WeeklyWeatherStats weeklyWeatherStats)
            => await _context.WeeklyWeatherStats.AddAsync(_mapper.Map<DbWeeklyWeatherStats>(weeklyWeatherStats));

    public async Task AddRangeAsync(List<WeeklyWeatherStats> weeklyWeatherStats)
    {
        var dbstats = _mapper.Map<List<DbWeeklyWeatherStats>>(weeklyWeatherStats);
        await _context.WeeklyWeatherStats.AddRangeAsync(dbstats);
    }

    public async Task SaveAsync()
            => await _context.SaveChangesAsync();
}