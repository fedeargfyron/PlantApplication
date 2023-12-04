using AutoMapper;
using Domain.Constants;
using Domain.Dtos.Plants;
using Domain.Entities;
using Domain.Extensions;
using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Security;
using Domain.Interfaces.Services;
using Serilog;

namespace Application.Services;

public class PlantService : IPlantService
{
    private readonly IPlantRepository _plantRepository;
    private readonly IApplicationUser _applicationUser;
    private readonly IExternalWeatherService _externalWeatherService;
    private readonly IExternalPlantRiskGetterService _externalPlantRiskGetterService;
    private readonly IMapper _mapper;

    public PlantService(IPlantRepository plantRepository,
        IApplicationUser applicationUser,
        IExternalWeatherService externalWeatherService,
        IExternalPlantRiskGetterService externalPlantRiskGetterService,
        IMapper mapper)
    {
        _plantRepository = plantRepository;
        _applicationUser = applicationUser;
        _externalWeatherService = externalWeatherService;
        _externalPlantRiskGetterService = externalPlantRiskGetterService;
        _mapper = mapper;
    }

    public async Task AddPlantAsync(PlantDto dto)
    {
        var maximumCalculatedWateringDay = await _applicationUser.GetUserMaximumCalculatedWateringDayAsync();
        var plant = _mapper.Map<Plant>(dto);
        plant.WateringDays = plant.WateringDaysFrequency.GetWateringDays(DateTime.Today, maximumCalculatedWateringDay);
        plant.PlantRisks = await GetPlantRisks(dto);
        await _plantRepository.AddPlantAsync(plant);
    }

    private async Task<List<PlantRisk>> GetPlantRisks(PlantDto dto)
    {
        var todayPlantRisks = await _plantRepository.TodayRisksByPlant(dto.ScientificName);
        if (todayPlantRisks.Any())
        {
            return _mapper.Map<List<PlantRisk>>(todayPlantRisks);
        }

        return await GetNewPlantRisks(dto);
    }

    private async Task<List<PlantRisk>> GetNewPlantRisks(PlantDto dto)
    {
        var weatherDto = await _externalWeatherService.GetWeatherDataAsync(dto.Latitude, dto.Longitude);
        var plantRisks = await _externalPlantRiskGetterService.GetPlantRisksAsync(weatherDto.Forecast.ForecastDays, new() { dto.ScientificName });
        return plantRisks.ConvertToEntitiesWithoutId();
    }

    public Task DeletePlantByIdAsync(int id)
    {
        _plantRepository.DeleteById(id);
        return _plantRepository.SaveChangesAsync();
    }

    public Task<List<Plant>> GetAllByUserAsync() 
        => _plantRepository.GetUserPlantsAsync(_applicationUser.GetUserId());

    public async Task<GetPlantByIdResultDto> GetPlantByIdAsync(int id)
    {
        var plant = await _plantRepository.GetByIdAsync(id);
        
        if(plant is null)
        {
            throw new ArgumentException("Plant doesnt exists");
        }

        return plant;
    } 

    public Task UpdatePlantAsync(int plantId, UpdatePlantDto dto) => _plantRepository.UpdateAsync(plantId, dto);

    public Task<List<RankedPlantDto>> GetRankedPlantsAsync()
        => _plantRepository.GetRankedPlantsAsync();
}
