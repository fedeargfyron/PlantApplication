using Domain.Dtos.Weather;

namespace Domain.Interfaces.Services;

public interface IWeatherService
{
    Task<GetWeatherDto> GetWeatherForecastAsync(decimal latitude, decimal longitude);
}