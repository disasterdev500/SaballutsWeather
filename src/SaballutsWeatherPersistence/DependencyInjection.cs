using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaballutsWeatherPersistence.DbModels;

namespace SaballutsWeatherPersistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SaballutsWeatherContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("SaballutsWeatherConnection")));

        return services;
    }
}
