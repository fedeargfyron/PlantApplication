using Domain.Constants;
using Domain.Interfaces.Security;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Security;

public class ApplicationUser : IApplicationUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ApplicationUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetUserId()
    {
        var subject = _httpContextAccessor.HttpContext
                          .User.Claims
                          .FirstOrDefault(claim => claim.Type == UserClaimConstants.UserIdClaim);

        if(subject == null)
        {
            throw new InvalidOperationException("User id not registered");
        }

        return Convert.ToInt32(subject.Value);
    }

    public DateTime GetUserMaximumCalculatedWateringDay()
    {
        var subject = _httpContextAccessor.HttpContext
                          .User.Claims
                          .FirstOrDefault(claim => claim.Type == UserClaimConstants.MaximumCalculatedWateringDay);

        if (subject == null)
        {
            throw new InvalidOperationException("User id not registered");
        }

        return Convert.ToDateTime(subject.Value);
    }
}