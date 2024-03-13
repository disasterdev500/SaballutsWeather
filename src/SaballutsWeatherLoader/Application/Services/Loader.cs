
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

        csvWeatherRecords = ConvertTimeStampsToUTC(csvWeatherRecords);
        var weatherRecords = new List<WeatherRecord>();
        foreach (var csvWeatherRecord in csvWeatherRecords)
        {
            weatherRecords.Add(_mapper.Map<WeatherRecord>(csvWeatherRecord));
        }

        // Remove duplicates
        weatherRecords = weatherRecords.GroupBy(x => x.Date).Select(x => x.Last()).ToList();

        await _batchProcessor.ProcessAsync(weatherRecords);

        var dailyResult = await _dailyWeatherStatsService.GenerateDailyWeatherStatsSinceLastAsync();
        if (dailyResult.IsFailure)
        {
            System.Console.WriteLine(dailyResult.Error);
            return;
        }

        var weeklyResult = await _weeklyWeatherStatsService.GenerateWeeklyWeatherStatsSinceLastAsync();
        if (weeklyResult.IsFailure)
        {
            System.Console.WriteLine(weeklyResult.Error);
            return;
        }

        var monthlyResult = await _monthlyWeatherStatsService.GenerateMonthlyWeatherStatsSinceLastAsync();
        if (monthlyResult.IsFailure)
        {
            System.Console.WriteLine(monthlyResult.Error);
            return;
        }

        var yearlyResult = await _yearlyWeatherStatsService.GenerateYearlyWeatherStatsSinceLastAsync();
        if (yearlyResult.IsFailure)
        {
            System.Console.WriteLine(yearlyResult.Error);
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
            throw new FileNotFoundException("");
        }

        Array.Sort(filesPath);

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

    private List<CsvWeatherRecord> ConvertTimeStampsToUTC(List<CsvWeatherRecord> csvWeatherRecords)
    {
        const string format = "yyyy/M/d H:mm";
        var timeZoneSpain = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

        DateTime lastAmbiguousDateTime = default;
        bool isFirstRound = true;

        foreach (var csvRecord in csvWeatherRecords)
        {
            var originalDateStr = csvRecord.Timestamp;
            var finalDateStr = "";
            if (DateTime.TryParseExact(originalDateStr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var originalParsedDateTime))
            {
                var inPlus1 = originalParsedDateTime;
                var inUTC = TimeZoneInfo.ConvertTime(originalParsedDateTime, timeZoneSpain, TimeZoneInfo.Utc);
                var isDST = timeZoneSpain.IsDaylightSavingTime(originalParsedDateTime);
                var isAmbiguous = timeZoneSpain.IsAmbiguousTime(originalParsedDateTime);
                var finalParsedDateTime = originalParsedDateTime.AddHours(-1);
                if (isDST) // if is in DST, we should substract an extra hour
                {
                    finalParsedDateTime = finalParsedDateTime.AddHours(-1);
                }

                if (!isAmbiguous) // if is not an ambiguous date, we restart ambiguous related vars
                {
                    lastAmbiguousDateTime = default;
                    isFirstRound = true;
                }

                if (isAmbiguous) // if is an ambiguous date
                {
                    if (originalParsedDateTime < lastAmbiguousDateTime) // if original date is minor than last ambiguous date means that it is the second hour of the ambiguous date range
                    {
                        isFirstRound = false;
                    }

                    if (isFirstRound) // if is the first round, we should substract an extra hour
                    {
                        finalParsedDateTime = finalParsedDateTime.AddHours(-1);
                    }

                    lastAmbiguousDateTime = originalParsedDateTime;
                }

                finalDateStr = finalParsedDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                csvRecord.Timestamp = finalDateStr;
            }
        }

        return csvWeatherRecords;
    }
}
