using SaballutsWeatherApplication.Abstractions;
using SaballutsWeatherDomain.Models;
using SaballutsWeatherApplication.Common.Abstractions.Repositories;

namespace SaballutsWeatherApplication.Behaviors;

public class RawWeatherRecordService(IRawWeatherRecordsRepository rawWeatherRecordRepository) : IRawWeatherRecordService
{
    private readonly IRawWeatherRecordsRepository _rawWeatherRecordRepository = rawWeatherRecordRepository;

    public async Task<RawWeatherRecord> GetByIDAsync(int id) => await _rawWeatherRecordRepository.GetById(id);

    public async Task<List<RawWeatherRecord>> GetByDateRangeAsync(DateTime initial, DateTime final) => await _rawWeatherRecordRepository.GetByIntervalTimeAsync(initial, final);

    public async Task AddAsync(RawWeatherRecord rawWeatherRecord)
    {
        var record = await _rawWeatherRecordRepository.GetById(rawWeatherRecord.Id);
        if (record is not null)
        {
            return;
        }
        await _rawWeatherRecordRepository.AddAsync(rawWeatherRecord);
        await _rawWeatherRecordRepository.SaveAsync();
    }

    public async Task AddRangeAsync(List<RawWeatherRecord> rawWeatherRecords)
    {
        await _rawWeatherRecordRepository.BulkUpsertAsync(rawWeatherRecords);
        await _rawWeatherRecordRepository.SaveAsync();
    }
}