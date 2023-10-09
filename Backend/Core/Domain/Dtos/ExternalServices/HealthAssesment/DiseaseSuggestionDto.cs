namespace Domain.Dtos.ExternalServices.HealthAssesment;

public class DiseaseSuggestionDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Probability { get; set; }
    public List<SimilarImageDto> SimilarImages { get; set; } = new();
    public DetailsDto Details { get; set; } = new();
}