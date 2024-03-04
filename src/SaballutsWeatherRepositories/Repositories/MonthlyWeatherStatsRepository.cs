using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherPersistence.DbModels;
using SaballutsWeatherRepositories.Abstractions;
using System.Linq.Expressions;

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
        var records = await _context.MonthlyWeatherStats.OrderBy(d => d.Date).FirstAsync();
        return _mapper.Map<MonthlyWeatherStats>(records);
    }

    public async Task<MonthlyWeatherStats> GetLastAsync()
    {
        var records = await _context.MonthlyWeatherStats.OrderByDescending(d => d.Date).FirstAsync();
        return _mapper.Map<MonthlyWeatherStats>(records);
    }

    private async Task<List<MonthlyWeatherStats>> SearchAsync(Expression<Func<DbMonthlyWeatherStats, bool>> filter)
            => _mapper.Map<List<MonthlyWeatherStats>>(await _context.MonthlyWeatherStats.Where(filter).ToListAsync());

    public async Task AddAsync(MonthlyWeatherStats monthlyWeatherStats)
            => await _context.MonthlyWeatherStats.AddAsync(_mapper.Map<DbMonthlyWeatherStats>(monthlyWeatherStats));

    public async Task SaveAsync()
            => await _context.SaveChangesAsync();
}