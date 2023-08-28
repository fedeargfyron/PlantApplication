namespace Domain.Entities;

public class Permission : BaseEntity
{
    public Enums.PermissionType Value { get; set; }
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}