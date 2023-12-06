using Domain.Dtos.PlantRisks;
using Domain.Entities;
using Domain.Functions;
using Domain.Interfaces.Services;

namespace Application.Handlers.RiskAlerts.GetRiskAlertsHandler;

public class GetRiskAlertsHandler : IGetRiskAlertsHandler
{
    private readonly IWeatherService _weatherService;
    private readonly IPlantRisksService _plantRisksService;
    private readonly IWateringCalendarService _wateringCalendarService;

    public GetRiskAlertsHandler(IWeatherService weatherService, IPlantRisksService plantRisksService, IWateringCalendarService wateringCalendarService)
    {
        _weatherService = weatherService;
        _plantRisksService = plantRisksService;
        _wateringCalendarService = wateringCalendarService;
    }

    public async Task<List<PlantRiskDto>> HandleAsync(GetRiskAlertsHandlerRequest request)
    {
        var weatherDto = await _weatherService.GetWeatherForecastAsync(request.latitude, request.longitude);
        var plantsWithWateringDays = await _wateringCalendarService.GetCurrentPlantWithWateringDaysFromUser();
        var plantRiskDtos =  await _plantRisksService.GetPlantsRisksAsync(weatherDto.Forecast.ForecastDays, plantsWithWateringDays);
        return PlantRisksDtoFunctions.FilterPlantRisks(plantRiskDtos, weatherDto.Forecast.ForecastDays, plantsWithWateringDays);
    }
}
