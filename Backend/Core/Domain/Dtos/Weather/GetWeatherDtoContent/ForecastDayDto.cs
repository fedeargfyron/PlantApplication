namespace Domain.Dtos.Weather.GetWeatherDtoContent;

public class ForecastDayDto
{
    public string Date { get; set; } = string.Empty;
    public DayDto Day { get; set; } = new();
    public AstroDto Astro { get; set; } = new();
    public List<HourDto> Hour { get; set; } = new();
}