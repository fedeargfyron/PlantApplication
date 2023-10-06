namespace Domain.Interfaces.ExternalServices;

public interface IExternalImageUploaderService
{
    Task<string> UploadImageAsync(string base64Image, string fileName);
}
