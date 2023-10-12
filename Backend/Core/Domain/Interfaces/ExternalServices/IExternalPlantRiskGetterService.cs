using Domain.Dtos.PlantRisks;
using Domain.Dtos.Weather.GetWeatherDtoContent;

namespace Domain.Interfaces.ExternalServices;

public interface IExternalPlantRiskGetterService
{
    Task<List<GetPlantRiskResultDto>> GetPlantRisksAsync(List<ForecastDayDto> forecastDays, List<string> plantNames);
}
