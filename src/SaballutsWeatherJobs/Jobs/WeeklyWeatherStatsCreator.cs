using Quartz;
using SaballutsWeatherApplication.Abstractions;

namespace SaballutsWeatherJobs.Jobs;

[DisallowConcurrentExecution]
public class WeeklyWeatherStatsCreator(IWeeklyWeatherStatsService weeklyWeatherStatsService) : IJob
{
    private readonly IWeeklyWeatherStatsService _weeklyWeatherStatsService = weeklyWeatherStatsService;
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            var createResult = await _weeklyWeatherStatsService.GenerateWeeklyWeatherStatsSinceLastAsync();
            if (createResult.IsFailure)
            {
                System.Console.WriteLine($"{DateTime.UtcNow}: Error in Job {context.JobDetail.JobType}. Error: {createResult.Error}");
                return;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"{DateTime.UtcNow}: Error in Job {context.JobDetail.JobType}. Error: Unexpected error. Exception: {e}");
            return;
        }
        System.Console.WriteLine($"{DateTime.UtcNow}: Job {context.JobDetail.JobType} finished successfully");
    }
}
