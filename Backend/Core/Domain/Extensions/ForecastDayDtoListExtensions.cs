using Domain.Dtos.Weather.GetWeatherDtoContent;
using System.Text;

namespace Domain.Extensions;

public static class ForecastDayDtoListExtensions
{
    public static string GetGPTDaysParameter(this List<ForecastDayDto> forecastDays)
    {
        var days = forecastDays.Select((x, i) => $"{i}: Temperature: {x.Day.AverageTemperature}C, Humidity: {x.Day.AverageHumidity}%, Wind: {x.Day.MaxWind}km/h, Rain: {x.Day.TotalPrecipitation}mm");
        return string.Join("\r\n\t", days);
    }
}
