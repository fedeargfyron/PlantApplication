using Domain.Dtos.Plants.GetPlantResponse;

namespace Application.Handlers.Plants.RecognizePlantHandler;

public interface IRecognizePlantHandler
{
    Task<GetPlantResponseDto> HandleAsync(RecognizePlantHandlerRequest request);
}
