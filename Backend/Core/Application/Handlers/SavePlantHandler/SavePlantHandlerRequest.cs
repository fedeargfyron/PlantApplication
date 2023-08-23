namespace Application.Handlers.SavePlantHandler;

public class SavePlantHandlerRequest
{
    public string ImageUrl { get; set; } = string.Empty;
    public string ScientificName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool Outside { get; set; }
}
