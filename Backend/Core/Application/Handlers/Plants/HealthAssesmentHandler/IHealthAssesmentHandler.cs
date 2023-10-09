using Domain.Dtos.ExternalServices.HealthAssesment;

namespace Application.Handlers.Plants.HealthAssesmentHandler;

public interface IHealthAssesmentHandler
{
    Task<HealthAssesmentResultDto> HandleAsync(HealthAssesmentHandlerRequest request);
}
