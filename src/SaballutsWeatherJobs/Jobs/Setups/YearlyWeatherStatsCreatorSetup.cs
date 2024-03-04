using Quartz;
using Microsoft.Extensions.Options;

namespace SaballutsWeatherJobs.Jobs;

public class YearlyWeatherStatsCreatorSetup : IConfigureOptions<QuartzOptions>
{
    public void Configure(QuartzOptions options)
    {
        var key = JobKey.Create(nameof(YearlyWeatherStatsCreator));

        options.AddJob<YearlyWeatherStatsCreator>(JobBuilder => JobBuilder.WithIdentity(key))
            .AddTrigger(trigger => trigger.ForJob(key)
            .WithSimpleSchedule(schedule => schedule.WithIntervalInMinutes(30).RepeatForever())
        );
    }
}
