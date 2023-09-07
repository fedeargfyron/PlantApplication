using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.Handlers.Permissions.GetAllPermissionsHandler
{
    public class GetAllPermissionsHandler : IGetAllPermissionsHandler
    {
        private readonly IPermissionService _permissionService;

        public GetAllPermissionsHandler(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        public Task<List<Permission>> HandleAsync(GetAllPermissionsHandlerRequest request)
            => _permissionService.GetAllPermissionsAsync();
    }
}
