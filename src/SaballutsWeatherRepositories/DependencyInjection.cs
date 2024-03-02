
using Microsoft.Extensions.DependencyInjection;
using SaballutsWeatherRepositories.Repositories;
using SaballutsWeatherRepositories.Abstractions;

namespace SaballutsWeatherRepositories;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IWeatherRecordsRepository, WeatherRecordsRepository>();

        return services;
    }
}