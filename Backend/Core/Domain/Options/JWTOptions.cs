namespace Domain.Options;

public class JWTOptions
{
    public const string SectionName = "JWT";
    public string SecretKey { get; set; } = string.Empty;
}
