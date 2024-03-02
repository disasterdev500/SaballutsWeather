
using Microsoft.AspNetCore.Mvc;
using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeatherRecordController(IWeatherRecordGetter weatherRecordGetterService) : ControllerBase
{
    private readonly IWeatherRecordGetter _weatherRecordGetterService = weatherRecordGetterService;

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
