using Domain.Dtos.Plants.GetPlantResponse;

namespace Domain.Interfaces.ExternalServices;

public interface IExternalRecognizerService
{
    Task<GetPlantResponseDto?> RecognizePlant(string url);
}
