using Microsoft.EntityFrameworkCore;

namespace SaballutsWeatherPersistence.DbModels;

public class SaballutsWeatherContext(DbContextOptions<SaballutsWeatherContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<DbWeatherRecord>()
            .Property(e => e.Date)
            .HasConversion(new UtcDateTimeConverter());
        _ = modelBuilder.Entity<DbDailyWeatherStats>()
            .Property(e => e.Date)
            .HasConversion(new UtcDateTimeConverter());
    }

    public DbSet<DbWeatherRecord> WeatherRecords { get; set; }
    public DbSet<DbDailyWeatherStats> DailyWeatherStats { get; set; }
}