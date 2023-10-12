namespace Domain.Entities;

public class WateringDay : BaseEntity
{
    public DateTime Day { get; set; }
    public int PlantId { get; set; }
    public Plant Plant { get; set; } = null!;
}
