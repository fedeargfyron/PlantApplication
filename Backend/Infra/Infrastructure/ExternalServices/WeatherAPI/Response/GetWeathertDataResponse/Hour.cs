using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.WeatherAPI.Response.GetWeathertDataResponse;
public class Hour
{
    [JsonPropertyName("time")]
    public string Time { get; set; } = string.Empty;
    [JsonPropertyName("temp_c")]
    public double Temperature { get; set; }
    [JsonPropertyName("wind_kph")]
    public double Wind { get; set; }
    [JsonPropertyName("precip_mm")]
    public double Precipitation { get; set; }
    [JsonPropertyName("humidity")]
    public double Humidity { get; set; }
    [JsonPropertyName("will_it_rain")]
    public double WillItRain { get; set; }
    [JsonPropertyName("chance_of_rain")]
    public double ChanceOfRain { get; set; }
}