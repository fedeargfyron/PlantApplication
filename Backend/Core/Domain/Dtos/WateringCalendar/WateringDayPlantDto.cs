namespace Domain.Dtos.WateringCalendar;

public class WateringDayPlantDto
{
    public int Id { get; set; }
    public string WateringDaysFrequency { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ImageLink { get; set; } = string.Empty;
    public bool Outside { get; set; }
}
