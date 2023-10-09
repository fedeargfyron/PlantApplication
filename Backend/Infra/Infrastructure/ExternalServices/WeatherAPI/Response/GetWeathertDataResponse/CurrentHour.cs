using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.WeatherAPI.Response.GetWeathertDataResponse;

public class CurrentHour
{
    [JsonPropertyName("temp_c")]
    public double Temperature { get; set; }
    [JsonPropertyName("wind_kph")]
    public double Wind { get; set; }
    [JsonPropertyName("precip_mm")]
    public double Precipitation { get; set; }
    [JsonPropertyName("humidity")]
    public double Humidity { get; set; }
}