namespace Infrastructure.Options;

public class ImageKitOptions
{
    public const string ImageKitName = "ImageKit";
    public string BaseUrl { get; set; } = string.Empty;
    public string PublicKey { get; set; } = string.Empty;
    public string PrivateKey { get; set; } = string.Empty;
}
