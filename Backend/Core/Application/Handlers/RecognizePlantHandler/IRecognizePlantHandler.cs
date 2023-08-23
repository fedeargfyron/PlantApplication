using Domain.Dtos.Plants.GetPlantResponse;

namespace Application.Handlers.RecognizePlantHandler;

public interface IRecognizePlantHandler
{
    Task<GetPlantResponseDto> HandleAsync(RecognizePlantHandlerRequest request);
}
