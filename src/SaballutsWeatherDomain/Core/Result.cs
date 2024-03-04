namespace SaballutsWeatherDomain.Core;

public class Result
{
    protected internal Result(bool isSuccess, string error)
    {
        if (!isSuccess && string.IsNullOrEmpty(error))
        {
            throw new ArgumentException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public string Error { get; }

    public static Result Ok() => new(true, string.Empty);
    public static Result Fail(string error) => new(false, error);

    public static Result<TValue> Ok<TValue>(TValue? value)
        where TValue : class
        => new Result<TValue>(value, true, string.Empty);

    public static Result<TValue> Fail<TValue>(string error)
        where TValue : class
        => new Result<TValue>(default, false, error);
}

public class Result<TValue> : Result
    where TValue : class
{
    private readonly TValue? _value;

    protected internal Result(TValue? tValue, bool isSuccess, string error)
        : base(isSuccess, error)
    {
        _value = tValue;
    }

    public TValue? Value() => _value;
}
