namespace Domain.Interfaces.Handlers;

public interface IImageKitHandler
{
    Task RecognizePlantAsync(string base64Image);
}
