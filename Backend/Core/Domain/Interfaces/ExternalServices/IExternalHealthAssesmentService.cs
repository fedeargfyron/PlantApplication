using Domain.Dtos.ExternalServices.HealthAssesment;
using Domain.Dtos.Plants;

namespace Domain.Interfaces.ExternalServices;

public interface IExternalHealthAssesmentService
{
    Task<HealthAssesmentResultDto> DoHealthAssestment(DoHealthAssestmentRequestDto requestDto);
}
