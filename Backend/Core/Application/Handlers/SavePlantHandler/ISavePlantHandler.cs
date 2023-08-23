namespace Application.Handlers.SavePlantHandler;

public interface ISavePlantHandler
{
    Task HandleAsync(SavePlantHandlerRequest request);
}
