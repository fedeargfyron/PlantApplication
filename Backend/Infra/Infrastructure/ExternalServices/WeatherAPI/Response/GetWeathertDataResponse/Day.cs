using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.WeatherAPI.Response.GetWeathertDataResponse;

public class Day
{
    [JsonPropertyName("maxtemp_c")]
    public double MaximumTemperature { get; set; }
    [JsonPropertyName("mintemp_c")]
    public double MinimumTemperature { get; set; }
    [JsonPropertyName("avgtemp_c")]
    public double AverageTemperature { get; set; }
    [JsonPropertyName("maxwind_kph")]
    public double MaxWind { get; set; }
    [JsonPropertyName("totalprecip_mm")]
    public double TotalPrecipitation { get; set; }
    [JsonPropertyName("avghumidity")]
    public double AverageHumidity { get; set; }
    [JsonPropertyName("daily_will_it_rain")]
    public double WillItRain { get; set; }
    [JsonPropertyName("daily_chance_of_rain")]
    public double ChanceOfRain { get; set; }
}