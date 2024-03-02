using Microsoft.Extensions.DependencyInjection;
using SaballutsWeatherApplication.Behaviors;
using SaballutsWeatherApplication.Abstractions;

namespace SaballutsWeatherApplication;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IWeatherRecordService, WeatherRecordService>();

        return services;
    }
}
