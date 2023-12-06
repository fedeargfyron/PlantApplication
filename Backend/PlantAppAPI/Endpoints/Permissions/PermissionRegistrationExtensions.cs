using Application.Handlers.Groups.GetAllGroupsHandler;
using Application.Handlers.Permissions.GetAllPermissionsHandler;
using AutoMapper;
using Domain.Enums;
using PlantAppAPI.Endpoints.Actions.Response;

namespace PlantAppAPI.Actions;

public static class PermissionRegistrationExtensions
{
    public static void RegisterPermissionAPIs(this WebApplication app)
    {
        var groups = app.MapGroup("/permissions");

        groups.MapGet("/", async (IGetAllPermissionsHandler handler, IMapper mapper) =>
        {
            var result = await handler.HandleAsync(new ());
            return TypedResults.Ok(mapper.Map<List<GetAllPermissionsResponse>>(result));
        }).RequireAuthorization(PermissionType.GetPermissions.ToString());
    }
}
