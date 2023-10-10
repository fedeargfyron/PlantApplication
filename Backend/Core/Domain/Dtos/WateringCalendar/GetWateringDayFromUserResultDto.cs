namespace Domain.Dtos.WateringCalendar;

public record GetWateringDayFromUserResultDto(DateTime Day, List<WateringDayPlantDto> WateringDayPlantsDtos);