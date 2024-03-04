
using SaballutsWeatherDomain.Core;

namespace SaballutsWeatherDomain.Extensions;

public static class ResultExtensions
{
    public static Result<T> ToResult<T>(this T? value, string errorMessage)
        where T : class
    {
        return value is null ? Result.Fail<T>(errorMessage) : Result.Ok<T>(value);
    }
}
