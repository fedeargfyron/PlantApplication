using Domain.Dtos.Plants;
using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

public class UploadPlantService : IUploadPlantService
{
    private readonly IExternalImageUploaderService _externalImageKitService;
    public UploadPlantService(IExternalImageUploaderService externalImageKitService)
    {
        _externalImageKitService = externalImageKitService;
    }

    public Task<string> UploadImageAsync(string base64Image, string fileName) 
        => _externalImageKitService.UploadImageAsync(base64Image, fileName);

}
