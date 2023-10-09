namespace Domain.Dtos.ExternalServices.HealthAssesment;

public class DetailsDto
{
    public string Description { get; set; } = string.Empty;
    public List<string> CommonNames { get; set; } = new();
}