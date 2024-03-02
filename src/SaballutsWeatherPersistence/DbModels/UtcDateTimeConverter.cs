using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SaballutsWeatherPersistence.DbModels;

public class UtcDateTimeConverter : ValueConverter<DateTime, DateTime>
{
    public UtcDateTimeConverter(ConverterMappingHints? mappingHints = null)
        : base(
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc),   // Indicate that DateTime is in UTC
            v => v,   // Convert UTC DateTime back to DateTime without modification
            mappingHints)
    { }
}