using Quartz;

namespace SaballutsWeatherJobs.Jobs;

[DisallowConcurrentExecution]
public class DailyWeatherStatsCreator() : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        System.Console.WriteLine($"{DateTime.UtcNow} Execute");
    }
}
