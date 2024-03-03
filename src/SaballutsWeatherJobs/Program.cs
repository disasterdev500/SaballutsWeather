using Quartz;
using SaballutsWeatherJobs.Jobs;
using SaballutsWeatherApplication;
using SaballutsWeatherRepositories;
using SaballutsWeatherPersistence;
using SaballutsWeatherUtilities;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddQuartz();

        builder.Services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

        builder.Services.ConfigureOptions<DailyWeatherStatsCreatorSetup>();

        // Saballut's Weather services
        builder.Services.AddApplication();
        builder.Services.AddUtilities();
        builder.Services.AddRepositories();
        builder.Services.AddPersistence(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.Run();
    }
}