using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SaballutsWeatherPersistence.DbModels;

public class SaballutsWeatherContextFactory : IDesignTimeDbContextFactory<SaballutsWeatherContext>
{
    public SaballutsWeatherContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SaballutsWeatherContext>();
        optionsBuilder.UseNpgsql("Host=localhost; Database=saballutsweather; Username=postgres; Password=postgres");

        return new SaballutsWeatherContext(optionsBuilder.Options);
    }
}