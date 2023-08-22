namespace Domain.Interfaces.ExternalServices;

public interface IExternalImageKitService
{
    Task<string> UploadImageAsync(string base64Image);
}
