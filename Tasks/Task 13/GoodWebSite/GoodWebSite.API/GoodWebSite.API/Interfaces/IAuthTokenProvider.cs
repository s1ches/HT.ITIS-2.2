using System.Security.Claims;
using GoodWebSite.DAL.Entities;

namespace GoodWebSite.Interfaces;

public interface IAuthTokenProvider
{ 
    string GenerateAccessToken(User user);

    public string GenerateAccessTokenByClaims(IEnumerable<Claim> authClaims);
}