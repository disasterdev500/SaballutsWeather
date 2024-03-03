
using Microsoft.AspNetCore.Mvc;
using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MonthlyWeatherStatsController(IMonthlyWeatherStatsService monthlyWeatherStatsService) : ControllerBase
{
    private readonly IMonthlyWeatherStatsService _monthlyWeatherStatsService = monthlyWeatherStatsService;

    [HttpGet("{timestamp}")]
    public async Task<ActionResult<MonthlyWeatherStats>> GetMonthlyWeatherStatsAsync(DateTime timestamp)
    {
        MonthlyWeatherStats? stats = null;
        try
        {
            stats = await _monthlyWeatherStatsService.GetByIDAsync(timestamp);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return (stats == null) ? NotFound() : Ok(stats);
    }
}
