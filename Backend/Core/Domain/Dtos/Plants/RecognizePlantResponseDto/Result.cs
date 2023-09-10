namespace Domain.Dtos.Plants.RecognizePlantResponseDto;

public class Result
{
    public float Score { get; set; }
    public Species Species { get; set; } = new();
    public List<Image> Images { get; set; } = new();
}