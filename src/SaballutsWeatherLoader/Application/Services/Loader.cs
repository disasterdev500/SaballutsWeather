
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using AutoMapper;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherLoader.Dtos;
using SaballutsWeatherLoader.Utilities.Mapper;

namespace SaballutsWeatherLoader.Application.Services;

public interface ILoader
{
    Task Load();
}

public class Loader : ILoader
{
    private readonly IMapper _mapper;
    private readonly IBatchProcessor<WeatherRecord> _batchProcessor;

    private readonly IDailyWeatherStatsService _dailyWeatherStatsService;
    private readonly IWeeklyWeatherStatsService _weeklyWeatherStatsService;
    private readonly IMonthlyWeatherStatsService _monthlyWeatherStatsService;
    private readonly IYearlyWeatherStatsService _yearlyWeatherStatsService;

    public Loader(IBatchProcessor<WeatherRecord> batchProcessor,
        IMapper mapper,
        IDailyWeatherStatsService dailyWeatherStatsService,
        IWeeklyWeatherStatsService weeklyWeatherStatsService,
        IMonthlyWeatherStatsService monthlyWeatherStatsService,
        IYearlyWeatherStatsService yearlyWeatherStatsService)
    {
        _batchProcessor = batchProcessor;
        _mapper = mapper;
        _dailyWeatherStatsService = dailyWeatherStatsService;
        _weeklyWeatherStatsService = weeklyWeatherStatsService;
        _monthlyWeatherStatsService = monthlyWeatherStatsService;
        _yearlyWeatherStatsService = yearlyWeatherStatsService;
    }

    public async Task Load()
    {
        var csvWeatherRecords = new List<CsvWeatherRecord>();
        var filesPath = GetFilesPath();

        foreach (var filePath in filesPath)
        {
            csvWeatherRecords.AddRange(Read(filePath));
        }

        var weatherRecords = new List<WeatherRecord>();
        foreach (var csvWeatherRecord in csvWeatherRecords)
        {
            try
            {
                weatherRecords.Add(_mapper.Map<WeatherRecord>(csvWeatherRecord));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        var groupedData = weatherRecords
            .GroupBy(item => item.Date)
            .Where(group => group.Count() > 1);

        foreach (var group in groupedData)
        {
            DateTime baseDate = group.Key; // Take the date from the group

            foreach (var item in group.Skip(1)) // Skip the original item in the group
            {
                // Add 5 seconds to the Date property for subsequent items
                item.Date = baseDate.AddSeconds(5);
            }
        }

        await _batchProcessor.ProcessAsync(weatherRecords);

        var dailyResult = await _dailyWeatherStatsService.GenerateDailyWeatherStatsSinceLastAsync();
        if (dailyResult.IsFailure)
        {
            System.Console.WriteLine(dailyResult.Error);
            return;
        }

        var weeklyResult = await _weeklyWeatherStatsService.GenerateWeeklyWeatherStatsSinceLastAsync();
        if (dailyResult.IsFailure)
        {
            return;
        }

        var monthlyResult = await _monthlyWeatherStatsService.GenerateMonthlyWeatherStatsSinceLastAsync();
        if (dailyResult.IsFailure)
        {
            return;
        }

        var yearlyResult = await _yearlyWeatherStatsService.GenerateYearlyWeatherStatsSinceLastAsync();
        if (dailyResult.IsFailure)
        {
            return;
        }
    }

    private string[] GetFilesPath()
    {
        const string FILE_EXTENSION = ".csv";
        const string DATA_FOLDER_EXTENSION = "data";

        var dataDirectoryPath = AppDomain.CurrentDomain.BaseDirectory + DATA_FOLDER_EXTENSION;

        if (!Directory.Exists(dataDirectoryPath))
        {
            throw new ArgumentException("Directory doesn't exist");
        }

        var filesPath = Directory.GetFiles(dataDirectoryPath).Where(f => f.EndsWith(FILE_EXTENSION) || f.EndsWith(FILE_EXTENSION.ToUpper())).ToArray();
        if (filesPath.Length == 0)
        {
            return filesPath;
        }

        return filesPath;
    }

    private List<CsvWeatherRecord> Read(string filePath)
    {
        List<CsvWeatherRecord> records;

        try
        {
            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                csv.Context.RegisterClassMap<WeatherCsvMap>();
                records = csv.GetRecords<CsvWeatherRecord>().ToList();
            }
        }
        catch (Exception e)
        {
            throw new Exception("Unexpected error while reading csv file", e);
        }

        return records;
    }
}
