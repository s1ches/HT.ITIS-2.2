using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAuth.API.Data.Entities;
using OAuth.API.Interfaces;
using OAuth.API.Models.DTOs.GetIdentityToken;
using OAuth.API.Models.DTOs.PostGetAccessToken;
using OAuth.API.Models.DTOs.PostRefreshToken;
using OAuth.API.Models.GoogleResponseDTOs;

namespace OAuth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OAuthController(
    IAppDbContext dbContext,
    IJwtService jwtService,
    IConfiguration configuration,
    HttpClient client) : ControllerBase
{
    [HttpPost("GetAccessToken")]
    public async Task<PostGetAccessTokenResponse> GetAccessToken([FromBody] PostGetAccessTokenRequest request, CancellationToken cancellationToken)
    {
        var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
        {
            new("client_id", configuration["Authentication:Google:AppId"]!),
            new("client_secret", configuration["Authentication:Google:AppSecret"]!),
            new("redirect_uri", configuration["ExternalLoginRedirect"]!),
            new("grant_type", "authorization_code"),
            new("code", request.Code)
        });
        
        var response = await client.PostAsync(GoogleDefaults.TokenEndpoint, content, cancellationToken);
        var stringResult = await response.Content.ReadAsStringAsync(cancellationToken);

        var jwt = JsonSerializer.Deserialize<GetAccessTokensDto>(stringResult);
        var claims = jwtService.GetPrincipalFromToken(jwt!.IdentityToken);
        var email = claims.First(x => x.Type == "email").Value;

        var userTokens = await dbContext.UserTokens
            .FirstOrDefaultAsync(x => x.Email == email, cancellationToken: cancellationToken);

        var result = JsonSerializer.Deserialize<UserTokensDto>(stringResult)!;

        if (userTokens is null)
        {
            userTokens = new UserTokens
            {
                AccessToken = result.AccessToken,
                RefreshToken = result.RefreshToken,
                IdentityToken = result.IdentityToken,
                Email = email,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                ExpiresIn = result.ExpiresIn
            };
            
            await dbContext.UserTokens.AddAsync(userTokens, cancellationToken);
        }
        else
        {
            userTokens.AccessToken = result.AccessToken;
            userTokens.UpdateDate = DateTime.UtcNow;
            userTokens.ExpiresIn = result.ExpiresIn;
            userTokens.RefreshToken = string.IsNullOrWhiteSpace(result.RefreshToken)
                ? userTokens.RefreshToken
                : result.RefreshToken;
            userTokens.IdentityToken = result.IdentityToken;
        }
        
        await dbContext.SaveChangesAsync(cancellationToken);

        return new PostGetAccessTokenResponse { AccessToken = result.AccessToken };
    }
    
    [HttpPost("RefreshToken")]
    public async Task<PostRefreshTokenResponse> RefreshToken(
        [FromBody] PostRefreshTokenRequest request,
        CancellationToken cancellationToken)
    {
        var userTokens = await dbContext.UserTokens
            .FirstOrDefaultAsync(x => 
                x.Email == request.Email && x.AccessToken == request.AccessToken, cancellationToken);

        if (userTokens is null)
            throw new BadHttpRequestException($"User with email {request.Email} was not found",
                (int)HttpStatusCode.BadRequest);
        
        var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
        {
            new("client_id", configuration["Authentication:Google:AppId"]!),
            new("client_secret", configuration["Authentication:Google:AppSecret"]!),
            new ("refresh_token", userTokens.RefreshToken),
            new("grant_type", "refresh_token"),
        });

        var response = await client.PostAsync(GoogleDefaults.TokenEndpoint, content, cancellationToken);
        var result =
            JsonSerializer.Deserialize<GetRefreshTokenDto>(await response.Content.ReadAsStringAsync(cancellationToken))!;

        userTokens.AccessToken = result.AccessToken;
        userTokens.ExpiresIn = result.ExpiresIn;
        userTokens.UpdateDate = DateTime.UtcNow;

        await dbContext.SaveChangesAsync(cancellationToken);

        return new PostRefreshTokenResponse() { AccessToken = result.AccessToken };
    }

    [HttpPost("GetIdentityToken")]
    public async Task<GetIdentityTokenResponse?> GetIdentityToken([FromBody] GetIdentityTokenRequest request, CancellationToken cancellationToken)
    {
        var userTokens = await dbContext.UserTokens
            .FirstOrDefaultAsync(x => x.AccessToken == request.AccessToken, cancellationToken);

        return new GetIdentityTokenResponse { IdentityToken = userTokens?.IdentityToken };
    }
}