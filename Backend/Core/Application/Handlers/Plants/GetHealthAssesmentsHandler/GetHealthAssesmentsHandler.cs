using Domain.Dtos.Plants;
using Domain.Interfaces.Services;

namespace Application.Handlers.Plants.GetHealthAssesmentsHandler;

public class GetHealthAssesmentsHandler : IGetHealthAssesmentsHandler
{
    private readonly IHealthAssesmentService _healthAssesmentService;

    public GetHealthAssesmentsHandler(IHealthAssesmentService healthAssesmentService)
    {
        _healthAssesmentService = healthAssesmentService;
    }

    public Task<List<GetHealthAssesmentDto>> HandleAsync(GetHealthAssesmentsHandlerRequest request)
        => _healthAssesmentService.GetHealthAssesmentsAsync();
}
