
using Microsoft.AspNetCore.Mvc;
using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class YearlyWeatherStatsController(IYearlyWeatherStatsService yearlyWeatherStatsService) : ControllerBase
{
    private readonly IYearlyWeatherStatsService _yearlyWeatherStatsService = yearlyWeatherStatsService;

    [HttpGet("{timestamp}")]
    public async Task<ActionResult<YearlyWeatherStats>> GetYearlyWeatherStatsAsync(DateTime timestamp)
    {
        YearlyWeatherStats? stats = null;
        try
        {
            stats = await _yearlyWeatherStatsService.GetByIDAsync(timestamp);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return (stats == null) ? NotFound() : Ok(stats);
    }
}
