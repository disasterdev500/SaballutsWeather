

namespace SaballutsWeatherLoader.Application.Services;

public interface IBatchTask<T>
{
    Task Execute(IEnumerable<T> elements);
}
