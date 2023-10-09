namespace Domain.Dtos.Weather.GetWeatherDtoContent;
public class HourDto
{
    public string Time { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public double Wind { get; set; }
    public double Precipitation { get; set; }
    public double Humidity { get; set; }
    public double WillItRain { get; set; }
    public double ChanceOfRain { get; set; }
}