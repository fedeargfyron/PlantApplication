using Domain.Dtos.Plants.RecognizePlantResponseDto;

namespace Domain.Interfaces.ExternalServices;

public interface IExternalRecognizerService
{
    Task<RecognizePlantResponseDto?> RecognizePlant(string url);
}
