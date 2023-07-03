namespace Domain.Entities;

public class Plant
{
    public int Id { get; set; }
    public string ScientificName { get; set; } = string.Empty;
    public string CommonName { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string ImageLink { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public bool Outside { get; set; }
}
