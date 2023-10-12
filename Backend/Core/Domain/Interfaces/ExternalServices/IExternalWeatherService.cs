using Domain.Dtos.Weather;

namespace Domain.Interfaces.ExternalServices;

public interface IExternalWeatherService
{
    Task<GetWeatherDto> GetWeatherDataAsync(decimal latitude, decimal longitude);
}
