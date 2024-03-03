
using Microsoft.AspNetCore.Mvc;
using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DailyWeatherStatsController(IDailyWeatherStatsService dailyWeatherStatsService) : ControllerBase
{
    private readonly IDailyWeatherStatsService _dailyWeatherStatsService = dailyWeatherStatsService;

    [HttpGet("{timestamp}")]
    public async Task<ActionResult<DailyWeatherStats>> GetWeatherRecordAsync(DateTime timestamp)
    {
        DailyWeatherStats? stats = null;
        try
        {
            stats = await _dailyWeatherStatsService.GetByIDAsync(timestamp);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return (stats == null) ? NotFound() : Ok(stats);
    }
}
