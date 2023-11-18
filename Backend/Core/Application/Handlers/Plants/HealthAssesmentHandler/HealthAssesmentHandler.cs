using Domain.Dtos.ExternalServices.HealthAssesment;
using Domain.Interfaces.Services;

namespace Application.Handlers.Plants.HealthAssesmentHandler;

public class HealthAssesmentHandler : IHealthAssesmentHandler
{
    private readonly IHealthAssesmentService _healthAssesmentService;

    public HealthAssesmentHandler(IHealthAssesmentService healthAssesmentService)
    {
        _healthAssesmentService = healthAssesmentService;
    }

    public Task<HealthAssesmentResultDto> HandleAsync(HealthAssesmentHandlerRequest request)
        => _healthAssesmentService.DoHealthAssestment(new(request.Base64Image, request.Latitude, request.Longitude, request.PlantId, request.FileName));
}
