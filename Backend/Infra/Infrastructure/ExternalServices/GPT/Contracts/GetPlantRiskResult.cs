namespace Infrastructure.ExternalServices.GPT.Contracts;

public class GetPlantRiskResult
{
    public string Plant { get; set; } = string.Empty;
    public List<RiskResult> Risks { get; set; } = new();
}