using Domain.Dtos.Users;

namespace Domain.Interfaces.Services;

public interface ITokenService
{
    Task<string> GenerateToken(GetUserLoginResultDto getUserLoginResultDto);
}
