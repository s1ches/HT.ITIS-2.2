using System.Security.Claims;

namespace JWT.API.Interfaces;

public interface IJwtGenerator
{
    public string GenerateAccessToken(List<Claim> authClaims);
}