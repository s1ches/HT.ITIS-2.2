using System.Security.Claims;

namespace OAuth.API.Interfaces;

public interface IJwtService
{
    IEnumerable<Claim> GetPrincipalFromToken(string jwt);
}