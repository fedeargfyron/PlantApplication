namespace Domain.Dtos.Users;

public record UpdateUserDto(int Id, string Username, string? Location, List<int> GroupsIds);
