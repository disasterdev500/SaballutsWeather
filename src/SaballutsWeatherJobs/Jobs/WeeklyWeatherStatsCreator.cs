using Quartz;
using SaballutsWeatherApplication.Behaviors;

namespace SaballutsWeatherJobs.Jobs;

[DisallowConcurrentExecution]
public class WeeklyWeatherStatsCreator(WeeklyWeatherStatsService weeklyWeatherStatsService) : IJob
{
    private readonly WeeklyWeatherStatsService _weeklyWeatherStatsService = weeklyWeatherStatsService;
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            var createResult = await _weeklyWeatherStatsService.GenerateWeeklyWeatherStatsSinceLastAsync();
            if (createResult.IsFailure)
            {
                System.Console.WriteLine($"{DateTime.UtcNow}: Error in Job {context.JobDetail.JobType}. Error: {createResult.Error}");
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"{DateTime.UtcNow}: Error in Job {context.JobDetail.JobType}. Error: Unexpected error. Exception: {e}");
        }
        System.Console.WriteLine($"{DateTime.UtcNow}: Job {context.JobDetail.JobType} finished successfully");
    }
}
