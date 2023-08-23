namespace Domain.Dtos.Plants.GetPlantResponse;

public class Result
{
    public float Score { get; set; }
    public Species Species { get; set; } = new();
    public List<Image> Images { get; set; } = new();
}