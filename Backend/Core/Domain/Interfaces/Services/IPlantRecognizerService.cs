using Domain.Dtos.Plants.RecognizePlantResponseDto;

namespace Domain.Interfaces.Services;

public interface IPlantRecognizerService
{
    Task<RecognizePlantResponseDto> RecognizePlant(string url);
}
