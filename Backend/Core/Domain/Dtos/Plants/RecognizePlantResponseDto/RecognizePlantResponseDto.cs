namespace Domain.Dtos.Plants.RecognizePlantResponseDto;

public class RecognizePlantResponseDto
{
    public string BestMatch { get; set; } = string.Empty;
    public List<Result> Results { get; set; } = new();
}