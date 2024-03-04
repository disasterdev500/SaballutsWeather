using Quartz;
using Microsoft.Extensions.Options;

namespace SaballutsWeatherJobs.Jobs;

public class DailyWeatherStatsCreatorSetup : IConfigureOptions<QuartzOptions>
{
    public void Configure(QuartzOptions options)
    {
        var key = JobKey.Create(nameof(DailyWeatherStatsCreator));

        options.AddJob<DailyWeatherStatsCreator>(JobBuilder => JobBuilder.WithIdentity(key))
            .AddTrigger(trigger => trigger.ForJob(key)
            .WithSimpleSchedule(schedule => schedule.WithIntervalInMinutes(5).RepeatForever())
        );
    }
}
