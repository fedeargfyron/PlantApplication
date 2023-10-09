using Domain.Dtos.Weather.GetWeatherDtoContent;

namespace Domain.Dtos.Weather;

public class GetWeatherDto
{
    public CurrentHourDto CurrentHour { get; set; } = new();
    public ForecastDto Forecast { get; set; } = new();
}
