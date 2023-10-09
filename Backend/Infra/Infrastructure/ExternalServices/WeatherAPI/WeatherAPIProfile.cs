using AutoMapper;
using Domain.Dtos.Weather;
using Domain.Dtos.Weather.GetWeatherDtoContent;
using Infrastructure.ExternalServices.WeatherAPI.Response.GetWeathertDataResponse;

namespace Infrastructure.ExternalServices.WeatherAPI;

public class WeatherAPIProfile : Profile
{
    public WeatherAPIProfile()
    {
        CreateMap<GetWeathertDataResponse, GetWeatherDto>();
        CreateMap<Astro, AstroDto>();
        CreateMap<CurrentHour, CurrentHourDto>();
        CreateMap<Day, DayDto>();
        CreateMap<Forecast, ForecastDto>();
        CreateMap<ForecastDay, ForecastDayDto>();
        CreateMap<Hour, HourDto>();
    }
}
