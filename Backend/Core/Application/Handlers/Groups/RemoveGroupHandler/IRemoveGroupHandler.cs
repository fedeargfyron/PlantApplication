namespace Application.Handlers.Groups.RemoveGroupHandler;

public interface IRemoveGroupHandler
{
    Task HandleAsync(RemoveGroupHandlerRequest request);
}
