using Domain.Dtos.Plants;
using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

public class ImageKitService : IImageKitService
{
    private readonly IExternalImageKitService _externalImageKitService;
    public ImageKitService(IExternalImageKitService externalImageKitService)
    {
        _externalImageKitService = externalImageKitService;
    }

    public Task<string> UploadImageAsync(string base64Image) => _externalImageKitService.UploadImageAsync(base64Image);

}
