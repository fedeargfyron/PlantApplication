using Domain.Dtos.Plants;
using Domain.Interfaces.Services;

namespace Application.Handlers.Plants.GetHealthAssesmentsByIdHandler;

public class GetHealthAssesmentByIdHandler : IGetHealthAssesmentByIdHandler
{
    private readonly IHealthAssesmentService _healthAssesmentService;

    public GetHealthAssesmentByIdHandler(IHealthAssesmentService healthAssesmentService)
    {
        _healthAssesmentService = healthAssesmentService;
    }

    public Task<GetHealthAssesmentByIdDto> HandleAsync(GetHealthAssesmentByIdHandlerRequest request)
        => _healthAssesmentService.GetHealthAssesmentByIdAsync(request.Id);
}
