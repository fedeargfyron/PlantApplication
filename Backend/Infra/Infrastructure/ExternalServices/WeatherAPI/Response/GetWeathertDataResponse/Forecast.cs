using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.WeatherAPI.Response.GetWeathertDataResponse;

public class Forecast
{
    [JsonPropertyName("forecastday")]
    public List<ForecastDay> ForecastDays { get; set; } = new();
}