
using Microsoft.AspNetCore.Mvc;
using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeatherRecordController(IWeatherRecordService weatherRecordGetterService) : ControllerBase
{
    private readonly IWeatherRecordService _weatherRecordGetterService = weatherRecordGetterService;

    [HttpGet("{timestamp}")]
    public async Task<ActionResult<WeatherRecord>> GetWeatherRecordAsync(DateTime timestamp)
    {
        System.Console.WriteLine(timestamp);
        WeatherRecord? record = null;
        try
        {
            record = await _weatherRecordGetterService.GetByIDAsync(timestamp);
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Error en GetWeatherRecordAsync - Exception: {e}");
        }

        return (record == null) ? NotFound() : Ok(record);
    }
}
