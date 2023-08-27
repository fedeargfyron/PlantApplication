namespace Application.Handlers.Groups.RemoveGroupHandler;

public interface IRemoveGroupHandler
{
    void HandleAsync(RemoveGroupHandlerRequest request);
}
