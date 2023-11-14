using Domain.Dtos.Plants;

namespace Application.Handlers.Plants.GetHealthAssesmentsByIdHandler;

public interface IGetHealthAssesmentByIdHandler
{
    Task<GetHealthAssesmentByIdDto> HandleAsync(GetHealthAssesmentByIdHandlerRequest request);
}
