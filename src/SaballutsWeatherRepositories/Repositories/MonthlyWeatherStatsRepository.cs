using AutoMapper;
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

    public List<MonthlyWeatherStats> GetByIntervalTime(DateTime initial, DateTime final)
    {
        Expression<Func<DbMonthlyWeatherStats, bool>> filter = dbRecord => dbRecord.Date >= initial && dbRecord.Date < final;
        return Search(filter);
    }

    private List<MonthlyWeatherStats> Search(Expression<Func<DbMonthlyWeatherStats, bool>> filter)
            => _mapper.Map<List<MonthlyWeatherStats>>(_context.MonthlyWeatherStats.Where(filter).ToList());

    public async Task AddAsync(MonthlyWeatherStats monthlyWeatherStats)
            => await _context.MonthlyWeatherStats.AddAsync(_mapper.Map<DbMonthlyWeatherStats>(monthlyWeatherStats));

    public async Task SaveAsync()
            => await _context.SaveChangesAsync();
}