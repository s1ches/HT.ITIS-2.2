using System.Security.Claims;
using JWT.API.DAL.Entities;
using JWT.API.Interfaces;

namespace JWT.API.Services;

public class UserClaimsManager : IUserClaimsManager
{
    public List<Claim> GetUserClaims(User user)
    {
        var claims = new List<Claim>()
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.UserName)
        };

        foreach (var role in user.Roles)
            claims.Add(new Claim(ClaimTypes.Role, role.RoleName));

        return claims;
    }
}