namespace Domain.Dtos.PlantRisks;

public class GetPlantRiskResultDto
{
    public int Day { get; set; }
    public string Plant { get; set; } = string.Empty;
    public List<RiskDto> Risks { get; set; } = new();
}