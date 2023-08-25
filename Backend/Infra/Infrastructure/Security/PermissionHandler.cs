using Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Security;

public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (context.User == null)
        {
            context.Fail();
            return;
        }

        if(context.User.HasClaim(x => x.Type == requirement.Permission.ToString()))
        {
            context.Succeed(requirement);
            return;
        }
    }
}
public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(PermissionEnum permission)
    {
        Permission = permission;
    }

    public PermissionEnum Permission { get; }
}