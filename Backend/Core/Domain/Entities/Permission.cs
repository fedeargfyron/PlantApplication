namespace Domain.Entities;

public class Permission
{
    public int Id { get; set; }
    public Enums.PermissionType Value { get; set; }
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}