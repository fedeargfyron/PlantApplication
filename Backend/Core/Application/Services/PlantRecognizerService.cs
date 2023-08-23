using Domain.Dtos.Plants.GetPlantResponse;
using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Services;

namespace Application.Services;

public class PlantRecognizerService : IPlantRecognizerService
{
    private readonly IExternalRecognizerService _externalRecognizerService;

    public PlantRecognizerService(IExternalRecognizerService externalRecognizerService)
    {
        _externalRecognizerService = externalRecognizerService;
    }

    public Task<GetPlantResponseDto> RecognizePlant(string url) 
        => _externalRecognizerService.RecognizePlant(url);
}
