using Domain.Dtos.Weather;

namespace Domain.Interfaces.ExternalServices;

public interface IExternalWeatherService
{
    Task<GetWeatherDto> GetWeatherData(decimal latitude, decimal longitude);
}
