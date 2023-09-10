using Domain.Dtos.Plants.RecognizePlantResponseDto;

namespace Domain.Dtos.Plants;

public record GetPlantResponseDto(string BestMatch, List<Result> Results, string UserImageUrl);