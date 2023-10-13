using Domain.Enums;

namespace Domain.Entities;

public class PlantRisk
{
    public int Id { get; set; }
    public DateTime Day { get; set; }
    public string Risk { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ObtentionDate { get; set; } = DateTime.Today;
    public int PlantId { get; set; }
    public virtual Plant Plant { get; set; } = null!;
}
