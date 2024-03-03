
using Microsoft.AspNetCore.Mvc;
using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeeklyWeatherStatsController(IWeeklyWeatherStatsService weeklyWeatherStatsService) : ControllerBase
{
    private readonly IWeeklyWeatherStatsService _weeklyWeatherStatsService = weeklyWeatherStatsService;

    [HttpGet("{timestamp}")]
    public async Task<ActionResult<WeeklyWeatherStats>> GetDailyWeatherStatsAsync(DateTime timestamp)
    {
        WeeklyWeatherStats? stats = null;
        try
        {
            stats = await _weeklyWeatherStatsService.GetByIDAsync(timestamp);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return (stats == null) ? NotFound() : Ok(stats);
    }
}
