namespace Application.Handlers.Groups.AddGroupHandler;

public interface IAddGroupHandler
{
    Task HandleAsync(AddGroupHandlerRequest request);
}
