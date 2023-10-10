namespace Domain.Entities;

public class WateringDay
{
    public int Id { get; set; }
    public DateTime Day { get; set; }
    public int PlantId { get; set; }
    public Plant Plant { get; set; } = null!;
}
