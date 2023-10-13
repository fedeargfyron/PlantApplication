namespace Infrastructure.Options;

public class WeatherAPIOptions
{
    public const string WeatherAPIName = "WeatherAPI";
    public string BaseUrl { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public int ForecastDays { get; set; }
}
