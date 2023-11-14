using Domain.Dtos.ExternalServices.HealthAssesment;
using Domain.Dtos.Plants;

namespace Domain.Interfaces.Services;

public interface IHealthAssesmentService
{
    Task<HealthAssesmentResultDto> DoHealthAssestment(DoHealthAssestmentRequestDto requestDto);
    Task<List<GetHealthAssesmentDto>> GetHealthAssesmentsAsync();
    Task<GetHealthAssesmentByIdDto> GetHealthAssesmentByIdAsync(int id);
}