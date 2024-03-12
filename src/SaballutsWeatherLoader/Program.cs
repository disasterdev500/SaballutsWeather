using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaballutsWeatherLoader.Utilities.Mappers;
using SaballutsWeatherUtilities.Mappers;
using SaballutsWeatherLoader.Application.Services;
using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherApplication.Behaviors;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherRepositories;
using SaballutsWeatherPersistence;

internal class Program
{
    private static async global::System.Threading.Tasks.Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder();

        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddAutoMapper(typeof(CsvMappingProfile));

        builder.Services.AddScoped<IWeatherRecordService, WeatherRecordService>();

        builder.Services.Configure<BatchProcessorOptions>(builder.Configuration.GetSection("BatchProcessorOptions"));
        builder.Services.AddSingleton<IBatchTask<WeatherRecord>, WeatherRecordsLoader>();
        builder.Services.AddSingleton<IBatchProcessor<WeatherRecord>, BatchProcessor>();
        builder.Services.AddScoped<IDailyWeatherStatsService, DailyWeatherStatsService>();
        builder.Services.AddScoped<IWeeklyWeatherStatsService, WeeklyWeatherStatsService>();
        builder.Services.AddScoped<IMonthlyWeatherStatsService, MonthlyWeatherStatsService>();
        builder.Services.AddScoped<IYearlyWeatherStatsService, YearlyWeatherStatsService>();

        builder.Services.AddRepositories();
        builder.Services.AddPersistence(builder.Configuration);

        builder.Services.AddSingleton<ILoader, Loader>();

        var app = builder.Build();

        try
        {
            var service = app.Services.GetRequiredService<ILoader>();
            await service.Load();
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
        }
    }
}