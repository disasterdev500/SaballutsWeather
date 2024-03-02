using SaballutsWeatherUtilities.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace SaballutsWeatherUtilities;

public static class DependencyInjection
{
    public static IServiceCollection AddUtilities(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}