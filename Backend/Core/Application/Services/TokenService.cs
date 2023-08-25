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

    public async Task<string> GenerateToken(GetUserLoginResultDto getUserLoginResultDto)
    {
        var claims = new List<Claim>()
        {
            //new Claim(PermissionEnum.GetPlants.ToString(), PermissionEnum.GetPlants.ToString())
        };

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
