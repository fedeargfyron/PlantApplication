using Domain.Dtos.ExternalServices.HealthAssesment;

namespace Domain.Interfaces.ExternalServices;

public interface IExternalHealthAssesmentService
{
    Task<HealthAssesmentResultDto> DoHealthAssestment(DoHealthAssestmentRequestDto requestDto);
}
