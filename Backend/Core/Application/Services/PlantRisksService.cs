using Domain.Dtos.PlantRisks;
using Domain.Dtos.WateringCalendar;
using Domain.Dtos.Weather.GetWeatherDtoContent;
using Domain.Extensions;
using Domain.Functions;
using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Services;

namespace Application.Services;

public class PlantRisksService : IPlantRisksService
{
    private readonly IExternalPlantRiskGetterService _externalPlantRiskGetterService;

    public PlantRisksService(IExternalPlantRiskGetterService externalPlantRiskGetterService)
    {
        _externalPlantRiskGetterService = externalPlantRiskGetterService;
    }

    public async Task<List<PlantRiskDto>> GetPlantsRisksAsync(List<ForecastDayDto> forecastDays, List<GetWateringDayFromUserResultDto> wateringDays)
    {
        //TODO: Preguntar si existe en cache/bdd y obtener
        var scientificPlantNames = wateringDays.GetScientificNames();
        var plantsRisksResult = await _externalPlantRiskGetterService.GetPlantRisksAsync(forecastDays, scientificPlantNames);
        var plantRisksDtos = plantsRisksResult.ConvertToDtos(wateringDays);
        return PlantRisksFunctions.FilterPlantRisks(plantRisksDtos, forecastDays);
    }
}
