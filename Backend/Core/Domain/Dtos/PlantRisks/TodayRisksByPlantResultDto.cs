namespace Domain.Dtos.PlantRisks;

public class TodayRisksByPlantResultDto
{
    public DateTime Day { get; set; }
    public string Risk { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ObtentionDate { get; set; } = DateTime.Today;
}
