using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.WeatherAPI.Response.GetWeathertDataResponse;

public class Astro
{
    [JsonPropertyName("sunrise")]
    public string Sunrise { get; set; } = string.Empty;
    [JsonPropertyName("sunset")]
    public string Sunset { get; set; } = string.Empty;
}