namespace Domain.Dtos.Users;

public record GetUserByIdResultDto(string Username, string Email, string Location, IEnumerable<int> GroupsIds);