
namespace SaballutsWeatherLoader.Application.Services;

public interface IBatchProcessor<T>
{
    Task ProcessAsync(ICollection<T> elements);
}
