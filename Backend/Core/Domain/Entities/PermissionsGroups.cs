namespace Domain.Entities;

public class PermissionsGroups
{
    public int PermissionsId { get; set; }
    public int GroupsId { get; set; }
    public Permission Permission { get; set; } = new();
    public Group Group { get; set; } = new();
}
