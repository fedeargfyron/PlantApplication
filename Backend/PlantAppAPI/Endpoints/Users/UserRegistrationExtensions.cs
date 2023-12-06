using Application.Handlers.Users.AddUserHandler;
using Application.Handlers.Users.GetAllUsersHandler;
using Application.Handlers.Users.GetUserByIdHandler;
using Application.Handlers.Users.RecoverUserPasswordHandler;
using Application.Handlers.Users.RegisterUserHandler;
using Application.Handlers.Users.RemoveUserHandler;
using Application.Handlers.Users.ResetUserPaswordHandler;
using Application.Handlers.Users.UpdateUserHandler;
using AutoMapper;
using Azure.Core;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using PlantAppAPI.Endpoints.Users.Contracts.Request;

namespace PlantAppAPI.Endpoints.Users;

public static class UserRegistrationExtensions
{
    public static void RegisterUserAPIs(this WebApplication app)
    {
        var users = app.MapGroup("/users");

        users.MapGet("/", async (IGetAllUsersHandler handler) =>
        {
            var result = await handler.HandleAsync(new());
            return TypedResults.Ok(result);
        }).RequireAuthorization(PermissionType.GetUsers.ToString());

        users.MapGet("/{id}", async (IGetUserByIdHandler handler, int id) =>
        {
            var result = await handler.HandleAsync(new(id));
            return TypedResults.Ok(result);
        }).RequireAuthorization(PermissionType.GetUserById.ToString());

        users.MapPut("/{id}", async (IUpdateUserHandler handler, int id, [FromBody] PutUserRequest request) =>
        {
            await handler.HandleAsync(new(id, request.Username, request.Location, request.GroupsIds));
            return TypedResults.Ok();
        }).RequireAuthorization(PermissionType.UpdateUser.ToString());

        users.MapDelete("/{id}", async (IRemoveUserHandler handler, int id) =>
        {
            await handler.HandleAsync(new(id));
            return TypedResults.Ok();
        }).RequireAuthorization(PermissionType.DeleteUser.ToString());

        users.MapPost("/", async (IAddUserHandler handler, IMapper mapper, [FromBody] AddUserRequest request) =>
        {
            await handler.HandleAsync(new(request.Username, request.Email, request.Location, request.GroupsIds));
            return TypedResults.Ok();
        }).RequireAuthorization(PermissionType.AddUser.ToString());

        users.MapPost("/recover", async ([FromBody] RecoverUserPasswordHandlerRequest request, IRecoverUserPasswordHandler handler) =>
        {
            var result = await handler.HandleAsync(request);
            return TypedResults.Ok(result);
        }).RequireAuthorization(PermissionType.RecoverPassword.ToString());

        users.MapPost("/register", async ([FromBody] RegisterUserHandlerRequest request, IRegisterUserHandler handler) =>
        {
            await handler.HandleAsync(request);
            return TypedResults.Ok();
        });

        users.MapPost("/reset", async ([FromBody] ChangeUserPaswordHandlerRequest request, IChangeUserPaswordHandler handler) =>
        {
            var result = await handler.HandleAsync(request);
            return TypedResults.Ok(result);
        }).RequireAuthorization(PermissionType.ResetPassword.ToString());

        users.MapPost("/change", async ([FromBody] ChangeUserPaswordHandlerRequest request, IChangeUserPaswordHandler handler) =>
        {
            var result = await handler.HandleAsync(request);
            return TypedResults.Ok(result);
        }).RequireAuthorization(PermissionType.ChangePassword.ToString());
    }
}
