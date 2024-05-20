using System.Security.Claims;
using GoodWebSite.RazorExample.DAL.Entities;

namespace GoodWebSite.RazorExample.Interfaces;

public interface IAuthTokenProvider
{ 
    string GenerateAccessToken(User user);

    public string GenerateAccessTokenByClaims(IEnumerable<Claim> authClaims);
}