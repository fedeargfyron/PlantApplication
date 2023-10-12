namespace Domain.Dtos.Users;

public record GetUserByIdResultDto(string Username, string Email, string? Location, DateTime MaximumCalculatedWateringDay,  IEnumerable<int> GroupsIds);