using Domain.Dtos.PlantRisks;
using Domain.Dtos.WateringCalendar;
using Domain.Dtos.Weather.GetWeatherDtoContent;

namespace Domain.Interfaces.ExternalServices;

public interface IExternalPlantRiskGetterService
{
    Task<List<PlantRiskDto>> GetPlantRisksAsync(List<ForecastDayDto> forecastDays, List<GetWateringDayFromUserResultDto> wateringDays);
}
