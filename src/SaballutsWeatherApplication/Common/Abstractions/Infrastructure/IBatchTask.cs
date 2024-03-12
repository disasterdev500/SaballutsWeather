

namespace SaballutsWeatherApplication.Common.Abstractions.Infrastructure;

public interface IBatchTask<T>
{
    Task Execute(IEnumerable<T> elements);
}
