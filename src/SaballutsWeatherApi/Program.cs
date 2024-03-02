using SaballutsWeatherApplication;
using SaballutsWeatherUtilities;
using SaballutsWeatherRepositories;
using SaballutsWeatherPersistance;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Saballut's Weather services
        builder.Services.AddApplication();
        builder.Services.AddUtilities();
        builder.Services.AddRepositories();
        builder.Services.AddPersistance(builder.Configuration);


        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}