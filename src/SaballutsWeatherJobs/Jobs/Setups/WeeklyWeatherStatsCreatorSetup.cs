using Quartz;
using Microsoft.Extensions.Options;

namespace SaballutsWeatherJobs.Jobs;

public class WeeklyWeatherStatsCreatorSetup : IConfigureOptions<QuartzOptions>
{
    public void Configure(QuartzOptions options)
    {
        var key = JobKey.Create(nameof(WeeklyWeatherStatsCreator));

        options.AddJob<WeeklyWeatherStatsCreator>(JobBuilder => JobBuilder.WithIdentity(key))
            .AddTrigger(trigger => trigger.ForJob(key)
            .WithSimpleSchedule(schedule => schedule.WithIntervalInMinutes(10).RepeatForever())
        );
    }
}
