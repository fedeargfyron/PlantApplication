namespace Domain.Dtos.Weather.GetWeatherDtoContent;

public class DayDto
{
    public double MaximumTemperature { get; set; }
    public double MinimumTemperature { get; set; }
    public double AverageTemperature { get; set; }
    public double MaxWind { get; set; }
    public double TotalPrecipitation { get; set; }
    public double AverageHumidity { get; set; }
    public double WillItRain { get; set; }
    public double ChanceOfRain { get; set; }
}