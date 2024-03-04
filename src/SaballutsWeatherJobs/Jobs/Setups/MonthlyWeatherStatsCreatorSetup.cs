using Quartz;
using Microsoft.Extensions.Options;

namespace SaballutsWeatherJobs.Jobs;

public class MonthlyWeatherStatsCreatorSetup : IConfigureOptions<QuartzOptions>
{
    public void Configure(QuartzOptions options)
    {
        var key = JobKey.Create(nameof(MonthlyWeatherStatsCreator));

        options.AddJob<MonthlyWeatherStatsCreator>(JobBuilder => JobBuilder.WithIdentity(key))
            .AddTrigger(trigger => trigger.ForJob(key)
            .WithSimpleSchedule(schedule => schedule.WithIntervalInMinutes(15).RepeatForever())
        );
    }
}
