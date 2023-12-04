namespace Domain.Dtos.Plants;

public record RankedPlantDto(int Amount, string ScientificName, string CommonName, string WateringDaysFrequency, string? Cycle, IEnumerable<string> ImagesLink, bool Exterior, string CareLevel);