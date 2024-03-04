using Quartz;
using SaballutsWeatherApplication.Behaviors;

namespace SaballutsWeatherJobs.Jobs;

[DisallowConcurrentExecution]
public class YearlyWeatherStatsCreator(YearlyWeatherStatsService yearlyWeatherStatsService) : IJob
{
    private readonly YearlyWeatherStatsService _monthlyWeatherStatsService = yearlyWeatherStatsService;
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            var createResult = await _monthlyWeatherStatsService.GenerateMonthlyWeatherStatsSinceLastAsync();
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
