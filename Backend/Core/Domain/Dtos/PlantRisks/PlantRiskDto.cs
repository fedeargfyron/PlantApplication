namespace Domain.Dtos.PlantRisks;

public class PlantRiskDto
{
    public string PlantScientificName { get; set; } = string.Empty;
    public int PlantId { get; set; }
    public bool Outside { get; set; }
    public List<RiskDto> Risks { get; set; } = new();
}
