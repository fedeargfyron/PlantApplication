namespace Infrastructure.Options;

public class PlantIdOptions
{
    public const string PlantIdName = "PlantId";
    public string BaseUrl { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
}