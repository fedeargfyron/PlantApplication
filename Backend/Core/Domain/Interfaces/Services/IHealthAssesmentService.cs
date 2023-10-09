using Domain.Dtos.ExternalServices.HealthAssesment;

namespace Domain.Interfaces.Services;

public interface IHealthAssesmentService
{
    Task<HealthAssesmentResultDto> DoHealthAssestment(DoHealthAssestmentRequestDto requestDto);
}
