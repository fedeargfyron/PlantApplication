namespace Domain.Interfaces.Services;

public interface IUploadPlantService
{
    Task<string> UploadImageAsync(string base64Image, string fileName);
}
