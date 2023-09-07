using Domain.Entities;

namespace Application.Handlers.Permissions.GetAllPermissionsHandler;

public interface IGetAllPermissionsHandler
{
    Task<List<Permission>> HandleAsync(GetAllPermissionsHandlerRequest request);
}
