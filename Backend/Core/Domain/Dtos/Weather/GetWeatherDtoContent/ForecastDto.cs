namespace Domain.Dtos.Weather.GetWeatherDtoContent;

public class ForecastDto
{
    public List<ForecastDayDto> ForecastDays { get; set; } = new();
}