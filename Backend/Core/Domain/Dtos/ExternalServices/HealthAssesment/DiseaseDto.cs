namespace Domain.Dtos.ExternalServices.HealthAssesment;

public class DiseaseDto
{

    public List<DiseaseSuggestionDto> Suggestions { get; set; } = new();
}