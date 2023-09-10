namespace Domain.Dtos.Plants.RecognizePlantResponseDto;

public class Species
{
    public List<string> CommonNames { get; set; } = new();
    public string ScientificName { get; set; } = string.Empty;
}