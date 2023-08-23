namespace Domain.Dtos.Plants.GetPlantResponse;

public class Image
{
    public string Organ { get; set; } = string.Empty;
    public Url Url { get; set; } = new();
}