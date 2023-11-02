using Domain.Dtos.PlantRisks;
using Domain.Dtos.WateringCalendar;
using Domain.Dtos.Weather.GetWeatherDtoContent;

namespace Domain.Interfaces.Services;

public interface IPlantRisksService
{
    Task<List<PlantRiskDto>> GetPlantsRisksAsync(List<ForecastDayDto> forecastDays, List<GetPlantWithWateringDaysFromUserResultDto> wateringDays);
}
