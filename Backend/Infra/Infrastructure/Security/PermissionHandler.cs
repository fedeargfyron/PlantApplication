using Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Security;

public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        => await Task.Run(() =>
        {
            if (context.User is null)
            {
                context.Fail();
                return;
            }

            if (context.User.HasClaim(x => x.Type == requirement.Permission.ToString()))
            {
                context.Succeed(requirement);
            }
        });
}
public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(PermissionType permission)
    {
        Permission = permission;
    }

    public PermissionType Permission { get; }
}