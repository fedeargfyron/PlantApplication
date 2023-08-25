namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Location { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
