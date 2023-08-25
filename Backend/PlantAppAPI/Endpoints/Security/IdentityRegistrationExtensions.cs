using Application.Handlers.GenerateTokenHandler;
using Microsoft.AspNetCore.Mvc;

namespace PlantAppAPI.Endpoints.Security;

public static class IdentityRegistrationExtensions
{
    public static void RegisterSecurityAPIs(this WebApplication app)
    {
        var security = app.MapGroup("/security");

        security.MapPost("/", async ([FromBody] GenerateTokenHandlerRequest request, IGenerateTokenHandler handler) =>
        {
            var result = await handler.HandleAsync(request);
            return TypedResults.Ok(result);
        });
    }
}
