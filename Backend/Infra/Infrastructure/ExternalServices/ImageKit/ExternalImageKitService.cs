using Domain.Interfaces.ExternalServices;
using Imagekit.Sdk;
using Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace Infrastructure.ExternalServices.ImageKit;

public class ExternalImageKitService : IExternalImageUploaderService
{
    private readonly ImagekitClient _client;
    public ExternalImageKitService(IOptions<ImageKitOptions> options)
    {
        var clientConfiguration = options.Value;
        _client = new ImagekitClient(clientConfiguration.PublicKey, clientConfiguration.PrivateKey, clientConfiguration.BaseUrl);
    }

    public async Task<string> UploadImageAsync(string base64Image, string fileName)
    {
        var request = new FileCreateRequest
        {
            file = base64Image,
            fileName = fileName
        };
        var response = await _client.UploadAsync(request);
        return response.url;
    }
}
