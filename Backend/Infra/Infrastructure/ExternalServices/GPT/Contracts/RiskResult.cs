namespace Infrastructure.ExternalServices.GPT.Contracts;

public class RiskResult
{
    public int Day { get; set; }
    public string Risk { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}