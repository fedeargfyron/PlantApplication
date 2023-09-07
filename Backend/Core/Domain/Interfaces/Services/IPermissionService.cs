using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface IPermissionService
{
    Task<List<Permission>> GetAllPermissionsAsync();
}
