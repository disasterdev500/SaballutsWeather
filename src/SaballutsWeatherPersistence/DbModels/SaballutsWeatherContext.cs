using Microsoft.EntityFrameworkCore;

namespace SaballutsWeatherPersistence.DbModels;

public class SaballutsWeatherContext(DbContextOptions<SaballutsWeatherContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbWeatherRecord>().ToTable("WeatherRecord");
        modelBuilder.Entity<DbDailyWeatherStats>().ToTable("DailyWeatherStats");
        modelBuilder.Entity<DbWeeklyWeatherStats>().ToTable("WeeklyWeatherStats");
        modelBuilder.Entity<DbMonthlyWeatherStats>().ToTable("MonthlyWeatherStats");
        modelBuilder.Entity<DbYearlyWeatherStats>().ToTable("YearlyWeatherStats");


        _ = modelBuilder.Entity<DbWeatherRecord>()
            .Property(e => e.Date)
            .HasConversion(new UtcDateTimeConverter());
        _ = modelBuilder.Entity<DbDailyWeatherStats>()
            .Property(e => e.Date)
            .HasConversion(new UtcDateTimeConverter());
        _ = modelBuilder.Entity<DbWeeklyWeatherStats>()
            .Property(e => e.Date)
            .HasConversion(new UtcDateTimeConverter());
        _ = modelBuilder.Entity<DbMonthlyWeatherStats>()
            .Property(e => e.Date)
            .HasConversion(new UtcDateTimeConverter());
        _ = modelBuilder.Entity<DbYearlyWeatherStats>()
            .Property(e => e.Date)
            .HasConversion(new UtcDateTimeConverter());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<DbWeatherRecord> WeatherRecords { get; set; }
    public DbSet<DbDailyWeatherStats> DailyWeatherStats { get; set; }
    public DbSet<DbWeeklyWeatherStats> WeeklyWeatherStats { get; set; }
    public DbSet<DbMonthlyWeatherStats> MonthlyWeatherStats { get; set; }
    public DbSet<DbYearlyWeatherStats> YearlyWeatherStats { get; set; }
}