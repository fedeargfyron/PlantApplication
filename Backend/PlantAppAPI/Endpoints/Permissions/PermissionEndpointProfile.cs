using AutoMapper;
using Domain.Entities;
using PlantAppAPI.Endpoints.Actions.Response;

namespace PlantAppAPI.Endpoints.Permissions;

public class PermissionEndpointProfile : Profile
{
    public PermissionEndpointProfile()
    {
        CreateMap<Permission, GetAllPermissionsResponse>();
    }
}
