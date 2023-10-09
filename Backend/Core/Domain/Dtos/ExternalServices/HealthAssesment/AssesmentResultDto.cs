namespace Domain.Dtos.ExternalServices.HealthAssesment;

public class AssesmentResultDto
{
    public IsHealthyDto IsHealthy { get; set; } = new();
    public DiseaseDto Disease { get; set; } = new();
}