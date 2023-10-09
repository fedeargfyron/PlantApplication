using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.WeatherAPI.Response.GetWeathertDataResponse;

public class GetWeathertDataResponse
{
    [JsonPropertyName("current")]
    public CurrentHour CurrentHour { get; set; } = new();
    [JsonPropertyName("forecast")]
    public Forecast Forecast { get; set; } = new();
}