using System.Security.Claims;
using GoodWebSite.DAL.Entities;
using GoodWebSite.Interfaces;

namespace GoodWebSite.Services;

public class UserClaimsManager : IUserClaimsManager
{
    public IEnumerable<Claim> GetUserClaims(User user) =>
    [
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.UserName)
    ];
}