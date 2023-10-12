using Domain.Dtos.PlantRisks;
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
        var wateringDays = await _wateringCalendarService.GetCurrentWateringDaysFromUser();
        return await _plantRisksService.GetPlantsRisksAsync(weatherDto.Forecast.ForecastDays, wateringDays);
    }
}
