namespace Domain.Dtos.WateringCalendar;

public record WateringDayPlantDto(int Id, string WateringDaysFrequency, string Name, string ImageLink, bool Outside);
