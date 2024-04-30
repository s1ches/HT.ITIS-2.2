using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWT.API.BaseConfigOptions;
using JWT.API.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace JWT.API.Services;

public class JwtGenerator(IConfiguration configuration) : IJwtGenerator
{
    public string GenerateAccessToken(List<Claim> authClaims)
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