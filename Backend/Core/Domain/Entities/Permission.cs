using Domain.Enums;

namespace Domain.Entities;

public class Permission
{
    public int Id { get; set; }
    public PermissionEnum Value { get; set; }
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
