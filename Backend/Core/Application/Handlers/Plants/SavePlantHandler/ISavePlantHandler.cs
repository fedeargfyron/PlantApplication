namespace Application.Handlers.Plants.SavePlantHandler;

public interface ISavePlantHandler
{
    Task HandleAsync(SavePlantHandlerRequest request);
}
