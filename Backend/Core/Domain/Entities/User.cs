namespace Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Location { get; set; } = string.Empty;
    public DateTime MaximumCalculatedWateringDay { get; set; } = DateTime.Today.AddMonths(1);
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
    public virtual ICollection<Plant> Plants { get; set; } = new List<Plant>();
}
