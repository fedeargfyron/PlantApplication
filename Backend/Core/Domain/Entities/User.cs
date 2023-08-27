namespace Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Location { get; set; } = string.Empty;
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
