using Domain.Entities;

namespace Domain.Dtos.Users;

public record AddUserDto(string Username, string Email, string? Location, List<int> GroupsIds);