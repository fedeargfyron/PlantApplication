using Domain.Dtos.Weather;
using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Services;

namespace Application.Services;

public class WeatherService : IWeatherService
{
    private readonly IExternalWeatherService _externalWeatherService;

    public WeatherService(IExternalWeatherService externalWeatherService)
    {
        _externalWeatherService = externalWeatherService;
    }

    //TODO: Preguntar si existe en cache/bdd y obtener
    public Task<GetWeatherDto> GetWeatherForecastAsync(decimal latitude, decimal longitude)
        => _externalWeatherService.GetWeatherDataAsync(latitude, longitude);
}
