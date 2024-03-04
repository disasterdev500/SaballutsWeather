using Quartz;
using SaballutsWeatherApplication.Abstractions;

namespace SaballutsWeatherJobs.Jobs;

[DisallowConcurrentExecution]
public class DailyWeatherStatsCreator(IDailyWeatherStatsService dailyWeatherStatsService) : IJob
{
    private readonly IDailyWeatherStatsService _dailyWeatherStatsService = dailyWeatherStatsService;
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            var createResult = await _dailyWeatherStatsService.GenerateDailyWeatherStatsSinceLastAsync();
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
