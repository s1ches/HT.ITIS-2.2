using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using OAuth.API.Interfaces;

namespace OAuth.API.Services;

public class JwtService(IConfiguration configuration) : IJwtService
{
    public IEnumerable<Claim> GetPrincipalFromToken(string jwt) 
        => new JwtSecurityTokenHandler().ReadJwtToken(jwt).Claims;
}