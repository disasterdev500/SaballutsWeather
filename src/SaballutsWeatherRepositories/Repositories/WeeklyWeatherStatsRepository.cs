using AutoMapper;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherPersistence.DbModels;
using SaballutsWeatherRepositories.Abstractions;
using System.Linq.Expressions;

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

    public List<WeeklyWeatherStats> GetByIntervalTime(DateTime initial, DateTime final)
    {
        Expression<Func<DbWeeklyWeatherStats, bool>> filter = dbRecord => dbRecord.Date >= initial && dbRecord.Date < final;
        return Search(filter);
    }

    private List<WeeklyWeatherStats> Search(Expression<Func<DbWeeklyWeatherStats, bool>> filter)
            => _mapper.Map<List<WeeklyWeatherStats>>(_context.WeeklyWeatherStats.Where(filter).ToList());

    public async Task AddAsync(WeeklyWeatherStats weeklyWeatherStats)
            => await _context.WeeklyWeatherStats.AddAsync(_mapper.Map<DbWeeklyWeatherStats>(weeklyWeatherStats));

    public async Task SaveAsync()
            => await _context.SaveChangesAsync();
}