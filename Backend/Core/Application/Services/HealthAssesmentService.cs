using Domain.Dtos.ExternalServices.HealthAssesment;
using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Services;

namespace Application.Services;

public class HealthAssesmentService : IHealthAssesmentService
{
    private readonly IExternalHealthAssesmentService _externalHealthAssesmentService;

    public HealthAssesmentService(IExternalHealthAssesmentService externalHealthAssesmentService)
    {
        _externalHealthAssesmentService = externalHealthAssesmentService;
    }

    public Task<HealthAssesmentResultDto> DoHealthAssestment(DoHealthAssestmentRequestDto requestDto)
        => _externalHealthAssesmentService.DoHealthAssestment(requestDto);
}
