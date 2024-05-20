using System.Security.Claims;
using GoodWebSite.RazorExample.DAL.Entities;
using GoodWebSite.RazorExample.Interfaces;

namespace GoodWebSite.RazorExample.Services;

public class UserClaimsManager : IUserClaimsManager
{
    public IEnumerable<Claim> GetUserClaims(User user) =>
    [
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.UserName)
    ];
}