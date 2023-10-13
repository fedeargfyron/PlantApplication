using AutoMapper;
using Domain.Dtos.PlantRisks;
using Domain.Dtos.WateringCalendar;
using Domain.Dtos.Weather.GetWeatherDtoContent;
using Domain.Entities;
using Domain.Extensions;
using Domain.Functions;
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

    public async Task<List<PlantRiskDto>> GetPlantsRisksAsync(List<ForecastDayDto> forecastDays, List<GetWateringDayFromUserResultDto> wateringDays)
    {
        var todayPlantRisksExists = await _plantRiskRepository.TodayPlantRisksExistsAsync();
        if (todayPlantRisksExists)
        {
            return PlantRisksFunctions.FilterPlantRisks(await _plantRiskRepository.GetTodayPlantRisksAsync(), forecastDays, wateringDays);
        }

        var plantRisksDtos = await _externalPlantRiskGetterService.GetPlantRisksAsync(forecastDays, wateringDays);
        await _plantRiskRepository.AddAsync(plantRisksDtos.ConvertToEntities());
        return PlantRisksFunctions.FilterPlantRisks(plantRisksDtos, forecastDays, wateringDays);
    }
}
