namespace Application.Handlers.Groups.UpdateGroupHandler;

public interface IUpdateGroupHandler
{
    Task HandleAsync(UpdateGroupHandlerRequest request);
}
