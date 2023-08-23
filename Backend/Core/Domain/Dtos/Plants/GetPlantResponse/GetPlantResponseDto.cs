using System.Text.Json.Serialization;

namespace Domain.Dtos.Plants.GetPlantResponse;
public class GetPlantResponseDto
{
    public string BestMatch { get; set; } = string.Empty;
    public List<Result> Results { get; set; } = new();
}