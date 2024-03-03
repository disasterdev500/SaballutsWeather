using AutoMapper;
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

    public List<DailyWeatherStats> GetByIntervalTime(DateTime initial, DateTime final)
    {
        Expression<Func<DbDailyWeatherStats, bool>> filter = dbRecord => dbRecord.Date >= initial && dbRecord.Date < final;
        return Search(filter);
    }

    private List<DailyWeatherStats> Search(Expression<Func<DbDailyWeatherStats, bool>> filter)
            => _mapper.Map<List<DailyWeatherStats>>(_context.DailyWeatherStats.Where(filter).ToList());

    public async Task AddAsync(DailyWeatherStats dailyWeatherStats)
            => await _context.DailyWeatherStats.AddAsync(_mapper.Map<DbDailyWeatherStats>(dailyWeatherStats));

    public async Task SaveAsync()
            => await _context.SaveChangesAsync();
}