using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaballutsWeatherPersistance.DbModels;

namespace SaballutsWeatherPersistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SaballutsWeatherContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("SaballutsWeatherConnection")));

        return services;
    }
}
