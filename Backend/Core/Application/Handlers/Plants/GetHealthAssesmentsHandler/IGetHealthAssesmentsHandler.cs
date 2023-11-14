using Domain.Dtos.Plants;

namespace Application.Handlers.Plants.GetHealthAssesmentsHandler;

public interface IGetHealthAssesmentsHandler
{
    Task<List<GetHealthAssesmentDto>> HandleAsync(GetHealthAssesmentsHandlerRequest request);
}
