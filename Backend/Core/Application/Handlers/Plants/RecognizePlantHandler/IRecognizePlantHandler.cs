using Domain.Dtos.Plants;
using Domain.Dtos.Plants.RecognizePlantResponseDto;

namespace Application.Handlers.Plants.RecognizePlantHandler;

public interface IRecognizePlantHandler
{
    Task<GetPlantResponseDto> HandleAsync(RecognizePlantHandlerRequest request);
}
