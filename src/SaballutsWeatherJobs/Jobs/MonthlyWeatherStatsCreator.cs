using Quartz;
using SaballutsWeatherApplication.Abstractions;

namespace SaballutsWeatherJobs.Jobs;

[DisallowConcurrentExecution]
public class MonthlyWeatherStatsCreator(IMonthlyWeatherStatsService monthlyWeatherStatsService) : IJob
{
    private readonly IMonthlyWeatherStatsService _monthlyWeatherStatsService = monthlyWeatherStatsService;
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            var createResult = await _monthlyWeatherStatsService.GenerateMonthlyWeatherStatsSinceLastAsync();
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
