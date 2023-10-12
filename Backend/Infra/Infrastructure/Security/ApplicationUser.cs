using Domain.Constants;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Security;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Security;

public class ApplicationUser : IApplicationUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;

    public ApplicationUser(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
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

    public async Task<DateTime> GetUserMaximumCalculatedWateringDayAsync()
    {
        var userId = GetUserId();
        var user = await _userRepository.GetByIdAsync(userId);
        return user!.MaximumCalculatedWateringDay;
    }
}