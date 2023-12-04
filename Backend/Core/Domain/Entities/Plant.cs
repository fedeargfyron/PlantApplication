using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Plant : BaseEntity
{
    public string ScientificName { get; set; } = string.Empty;
    public string CommonName { get; set; } = string.Empty;
    public string WateringDaysFrequency { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string? Cycle { get; set; } = string.Empty;
    public string ImageLink { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public bool Outside { get; set; }
    public bool Exterior { get; set; }
    public string CareLevel { get; set; } = string.Empty;
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
    public virtual List<WateringDay> WateringDays { get; set; } = new();
    public virtual List<PlantRisk> PlantRisks { get; set; } = new();
    public virtual List<HealthAssesment> HealthAssesments { get; set; } = new();
}