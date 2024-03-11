
using Microsoft.Extensions.DependencyInjection;
using SaballutsWeatherRepositories.Repositories;
using SaballutsWeatherApplication.Common.Abstractions.Repositories;

namespace SaballutsWeatherRepositories;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IWeatherRecordsRepository, WeatherRecordsRepository>();
        services.AddScoped<IDailyWeatherStatsRepository, DailyWeatherStatsRepository>();
        services.AddScoped<IWeeklyWeatherStatsRepository, WeeklyWeatherStatsRepository>();
        services.AddScoped<IMonthlyWeatherStatsRepository, MonthlyWeatherStatsRepository>();
        services.AddScoped<IYearlyWeatherStatsRepository, YearlyWeatherStatsRepository>();

        return services;
    }
}