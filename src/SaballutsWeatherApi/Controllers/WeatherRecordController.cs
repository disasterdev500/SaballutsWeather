
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
        WeatherRecord? record = null;
        try
        {
            record = await _weatherRecordGetterService.GetByIDAsync(timestamp);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return (record == null) ? NotFound() : Ok(record);
    }

    [HttpGet()]
    public async Task<ActionResult<List<WeatherRecord>>> GetWeatherRecordByDateRange([FromQuery] DateTime initial, [FromQuery] DateTime final)
    {
        List<WeatherRecord>? records = null;
        try
        {
            records = _weatherRecordGetterService.GetByDateRange(initial, final);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return (records == null) ? NotFound() : Ok(records);
    }

    [HttpPost()]
    public async Task<ActionResult> CreateWeatherRecordAsync(WeatherRecord weatherRecord)
    {
        try
        {
            await _weatherRecordGetterService.AddAsync(weatherRecord);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return NoContent();
    }

    [HttpPost("load")]
    public async Task<ActionResult> CreateBatchWeatherRecordAsync(List<WeatherRecord> weatherRecords)
    {
        try
        {
            await _weatherRecordGetterService.AddRangeAsync(weatherRecords);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return NoContent();
    }
}
