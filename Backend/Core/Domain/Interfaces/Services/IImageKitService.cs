namespace Domain.Interfaces.Services;

public interface IImageKitService
{
    Task<string> UploadImageAsync(string base64Image);
}
