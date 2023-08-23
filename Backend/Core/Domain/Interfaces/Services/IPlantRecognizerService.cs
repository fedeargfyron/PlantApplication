using Domain.Dtos.Plants.GetPlantResponse;

namespace Domain.Interfaces.Services;

public interface IPlantRecognizerService
{
    Task<GetPlantResponseDto> RecognizePlant(string url);
}
