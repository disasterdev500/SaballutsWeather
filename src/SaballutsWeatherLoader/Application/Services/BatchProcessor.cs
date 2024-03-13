using Microsoft.Extensions.Options;
using SaballutsWeatherDomain.Models;

namespace SaballutsWeatherLoader.Application.Services;

public class BatchProcessor(IBatchTask<WeatherRecord> batchTask, IOptions<BatchProcessorOptions> options) : IBatchProcessor<WeatherRecord>
{
    private readonly IBatchTask<WeatherRecord> _batchTask = batchTask;
    private readonly IOptions<BatchProcessorOptions> _options = options;

    public async Task ProcessAsync(ICollection<WeatherRecord> elements)
    {
        System.Console.WriteLine($"numworkers: {_options.Value.NumWorkers} --- numItems: {_options.Value.NumItems}");

        var semaphore = new SemaphoreSlim(_options.Value.NumWorkers);
        var numTasks = (int)Math.Ceiling((decimal)elements.Count / _options.Value.NumItems);

        await Task.WhenAll(Enumerable.Range(0, numTasks).Select(async i =>
        {
            // Calculate the start index of the subarray
            int startIndex = i * _options.Value.NumItems;

            // Extract the subarray of elements
            var subItemsList = elements.Skip(startIndex).Take(_options.Value.NumItems);

            // Wait for semaphore before starting the task
            await semaphore.WaitAsync();

            try
            {
                // Process the subarray (replace with your actual processing logic)
                await _batchTask.Execute(subItemsList);
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"BatchProcessor: Exception {e}");
            }

            // Release semaphore after completing the task
            semaphore.Release();
        }));

        Console.WriteLine("All tasks completed.");
    }
}
