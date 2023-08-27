using Domain.Dtos.Plants.GetPlantResponse;
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
        var imageUrl = await _imageKitService.UploadImageAsync(request.Base64Image);
        return await _plantRecognizerService.RecognizePlant(imageUrl);
    }
}
