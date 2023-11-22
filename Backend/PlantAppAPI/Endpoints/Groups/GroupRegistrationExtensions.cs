using Application.Handlers.Groups.AddGroupHandler;
using Application.Handlers.Groups.GetAllGroupsHandler;
using Application.Handlers.Groups.GetGroupByIdHandler;
using Application.Handlers.Groups.RemoveGroupHandler;
using Application.Handlers.Groups.UpdateGroupHandler;
using AutoMapper;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using PlantAppAPI.Endpoints.Groups.Contracts.Request;
using PlantAppAPI.Endpoints.Groups.Contracts.Response;

namespace PlantAppAPI.Endpoints.Groups;

public static class ActionRegistrationExtensions
{
    public static void RegisterGroupAPIs(this WebApplication app)
    {
        var groups = app.MapGroup("/groups");

        groups.MapGet("/", async (IGetAllGroupsHandler handler, IMapper mapper) =>
        {
            var result = await handler.HandleAsync(new ());
            return TypedResults.Ok(mapper.Map<List<GetAllGroupsResponse>>(result));
        }).RequireAuthorization(PermissionType.GetGroups.ToString());

        groups.MapGet("/{id}", async (IGetGroupByIdHandler handler, IMapper mapper, int id) =>
        {
            var result = await handler.HandleAsync(new(id));
            return TypedResults.Ok(mapper.Map<GetGroupByIdResponse>(result));
        }).RequireAuthorization(PermissionType.GetGroupById.ToString());

        groups.MapPut("/{id}", async (IUpdateGroupHandler handler, IMapper mapper, int id, [FromBody] PutGroupRequest request) =>
        {
            await handler.HandleAsync(new(id, request.Name, request.Description, request.PermissionsIds, request.UsersIds));
            return TypedResults.Ok();
        }).RequireAuthorization(PermissionType.UpdateGroup.ToString());

        groups.MapDelete("/{id}", async (IRemoveGroupHandler handler, int id) =>
        {
            await handler.HandleAsync(new(id));
            return TypedResults.Ok();
        }).RequireAuthorization(PermissionType.DeleteGroup.ToString());

        groups.MapPost("/", async (IAddGroupHandler handler, IMapper mapper, [FromBody] AddGroupRequest request) =>
        {
            await handler.HandleAsync(mapper.Map<AddGroupHandlerRequest>(request));
            return TypedResults.Ok();
        }).RequireAuthorization(PermissionType.AddGroup.ToString());
    }
}
