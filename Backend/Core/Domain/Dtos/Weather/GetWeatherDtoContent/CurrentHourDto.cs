namespace Domain.Dtos.Weather.GetWeatherDtoContent;

public class CurrentHourDto
{
    public double Temperature { get; set; }
    public double Wind { get; set; }
    public double Precipitation { get; set; }
    public double Humidity { get; set; }
}