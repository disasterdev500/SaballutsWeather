
namespace SaballutsWeatherCommon.Extensions;

public static class DateTimeExtensions
{
    public static DateTime GetFirstDayOfWeek(this DateTime date)
    {
        int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
        return date.AddDays(-1 * diff).Date;
    }

    public static DateTime GetFirstDayOfMonth(this DateTime date)
    {
        return date.AddDays(-1 * (date.Day - 1)).Date;
    }

    public static DateTime GetLastDayOfMonth(this DateTime date)
    {
        return date.GetFirstDayOfMonth().AddMonths(1).AddDays(-1).Date;
    }

    public static DateTime GetFirstDayOfYear(this DateTime date)
    {
        return date.AddDays(-1 * (date.DayOfYear - 1)).Date;
    }

    public static DateTime GetLastDayOfYear(this DateTime date)
    {
        return date.GetFirstDayOfYear().AddYears(1).AddDays(-1).Date;
    }

}
