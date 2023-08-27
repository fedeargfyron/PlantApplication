using Domain.Dtos.Users;

namespace Domain.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(GetUserLoginResultDto getUserLoginResultDto);
}
