using Domain.Dtos.PlantRisks;
using Domain.Dtos.WateringCalendar;
using Domain.Dtos.Weather.GetWeatherDtoContent;
using Domain.Extensions;
using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

public class PlantRisksService : IPlantRisksService
{
    private readonly IExternalPlantRiskGetterService _externalPlantRiskGetterService;
    private readonly IPlantRiskRepository _plantRiskRepository;

    public PlantRisksService(IExternalPlantRiskGetterService externalPlantRiskGetterService, IPlantRiskRepository plantRiskRepository)
    {
        _externalPlantRiskGetterService = externalPlantRiskGetterService;
        _plantRiskRepository = plantRiskRepository;
    }

    public async Task<List<PlantRiskDto>> GetPlantsRisksAsync(List<ForecastDayDto> forecastDays, List<GetPlantWithWateringDaysFromUserResultDto> plantsWithWateringDays)
    {
        var todayPlantRisksExists = await _plantRiskRepository.TodayPlantRisksExistsAsync();
        if (todayPlantRisksExists)
        {
            return await _plantRiskRepository.GetTodayPlantRisksAsync();
        }

        var plantRiskResults = await _externalPlantRiskGetterService.GetPlantRisksAsync(forecastDays, plantsWithWateringDays.GetScientificNames());
        await _plantRiskRepository.AddAsync(plantRiskResults.ConvertToEntities(plantsWithWateringDays));
        return plantRiskResults.ConvertToDtos(plantsWithWateringDays);
    }
}
