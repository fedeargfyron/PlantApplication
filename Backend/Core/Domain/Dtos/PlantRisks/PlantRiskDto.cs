namespace Domain.Dtos.PlantRisks;

public class PlantRiskDto
{
    public int Day { get; set; }
    public string PlantScientificName { get; set; } = string.Empty;
    public int PlantId { get; set; }
    public bool Outside { get; set; }
    public List<RiskDto> Risks { get; set; } = new();
}
