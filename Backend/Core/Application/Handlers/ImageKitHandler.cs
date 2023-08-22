using Domain.Interfaces.Handlers;
using Domain.Interfaces.Services;

namespace Application.Handlers;

public class ImageKitHandler : IImageKitHandler
{
    private readonly IImageKitService _imageKitService;
    public ImageKitHandler(IImageKitService imageKitService)
    {
        _imageKitService = imageKitService;
    }

    public async Task RecognizePlantAsync(string base64Image)
    {
        var imageUrl = await _imageKitService.UploadImageAsync(base64Image);
    }
}
