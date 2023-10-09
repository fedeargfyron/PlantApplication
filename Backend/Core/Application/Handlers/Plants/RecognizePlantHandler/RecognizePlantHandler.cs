using Domain.Dtos.Plants;
using Domain.Interfaces.Services;

namespace Application.Handlers.Plants.RecognizePlantHandler;

public class RecognizePlantHandler : IRecognizePlantHandler
{
    private readonly IUploadPlantService _imageKitService;
    private readonly IPlantRecognizerService _plantRecognizerService;

    public RecognizePlantHandler(IUploadPlantService imageKitService,
        IPlantRecognizerService plantRecognizerService)
    {
        _imageKitService = imageKitService;
        _plantRecognizerService = plantRecognizerService;
    }

    public async Task<GetPlantResponseDto> HandleAsync(RecognizePlantHandlerRequest request)
    {
        var imageUrl = await _imageKitService.UploadImageAsync(request.Base64Image, request.FileName);
        var recognizedPlant = await _plantRecognizerService.RecognizePlant(imageUrl);
        return new(recognizedPlant.BestMatch, recognizedPlant.Results, imageUrl);
    }
}
