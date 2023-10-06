using Domain.Constants;
using Domain.Dtos.Users;
using Domain.Enums;
using Domain.Interfaces.Services;
using Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services;

public class TokenService : ITokenService
{
    private readonly JWTOptions _options;

    public TokenService(IOptions<JWTOptions> options)
    {
        _options = options.Value;
    }

    public string GenerateToken(GetUserLoginResultDto getUserLoginResultDto)
    {
        var claims = getUserLoginResultDto.Permissions.Select(x => new Claim(x.ToString(), x.ToString())).ToList();
        claims.Add(new Claim(UserClaimConstants.UserIdClaim, getUserLoginResultDto.Id.ToString()));
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
