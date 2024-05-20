using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GoodWebSite.RazorExample.Constants;
using GoodWebSite.RazorExample.DAL.Entities;
using GoodWebSite.RazorExample.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace GoodWebSite.RazorExample.Services;

public class AuthTokenProvider(IUserClaimsManager claimsManager, IConfiguration configuration) : IAuthTokenProvider
{
    public string GenerateAccessToken(User user)
    {
        var authClaims = claimsManager.GetUserClaims(user);

        return GenerateAccessTokenByClaims(authClaims);
    }
    
    public string GenerateAccessTokenByClaims(IEnumerable<Claim> authClaims)
    {
        var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!));
        
        var jwt = new JwtSecurityToken(issuer: configuration["JWT:ValidIssuer"],
            audience: configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddMinutes(JwtConfigOptions.AccessTokenLifetimeMinutes),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
    
}