using AutoMapper;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherPersistence.DbModels;
using SaballutsWeatherRepositories.Abstractions;
using System.Linq.Expressions;

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

    public List<YearlyWeatherStats> GetByIntervalTime(DateTime initial, DateTime final)
    {
        Expression<Func<DbYearlyWeatherStats, bool>> filter = dbRecord => dbRecord.Date >= initial && dbRecord.Date < final;
        return Search(filter);
    }

    private List<YearlyWeatherStats> Search(Expression<Func<DbYearlyWeatherStats, bool>> filter)
            => _mapper.Map<List<YearlyWeatherStats>>(_context.YearlyWeatherStats.Where(filter).ToList());

    public async Task AddAsync(YearlyWeatherStats yearlyWeatherStats)
            => await _context.YearlyWeatherStats.AddAsync(_mapper.Map<DbYearlyWeatherStats>(yearlyWeatherStats));

    public async Task SaveAsync()
            => await _context.SaveChangesAsync();
}