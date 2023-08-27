using Domain.Enums;

namespace Domain.Dtos.Users;

public class GetUserLoginResultDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<PermissionType> Permissions { get; set; } = new();
}
