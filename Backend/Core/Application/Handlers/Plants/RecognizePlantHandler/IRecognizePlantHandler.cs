using Domain.Dtos.Plants;

namespace Application.Handlers.Plants.RecognizePlantHandler;

public interface IRecognizePlantHandler
{
    Task<GetPlantResponseDto> HandleAsync(RecognizePlantHandlerRequest request);
}
