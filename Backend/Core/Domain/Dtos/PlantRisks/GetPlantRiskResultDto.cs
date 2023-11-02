namespace Domain.Dtos.PlantRisks;

public class GetPlantRiskResultDto
{
    public string PlantScientificName { get; set; } = string.Empty;
    public List<RiskDto> Risks { get; set; } = new();
}
