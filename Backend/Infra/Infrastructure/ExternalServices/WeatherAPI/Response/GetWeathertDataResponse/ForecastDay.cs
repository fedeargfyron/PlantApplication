using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.WeatherAPI.Response.GetWeathertDataResponse;


public class ForecastDay
{
    [JsonPropertyName("date")]
    public string Date { get; set; } = string.Empty;
    [JsonPropertyName("day")]
    public Day Day { get; set; } = new();
    [JsonPropertyName("astro")]
    public Astro Astro { get; set; } = new();
    [JsonPropertyName("hour")]
    public List<Hour> Hour { get; set; } = new();
}