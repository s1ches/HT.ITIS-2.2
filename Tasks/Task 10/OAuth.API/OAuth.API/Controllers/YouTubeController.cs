using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAuth.API.Interfaces;
using OAuth.API.Models.DTOs.YouTube.GetMyVideos;

namespace OAuth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class YouTubeController(IAppDbContext dbContext, HttpClient client) : ControllerBase
{
    [HttpPost("GetMyVideos")]
    public async Task<string> GetMyVideos(
        [FromBody] PostGetMyVideosRequest request,
        CancellationToken cancellationToken)
    {
        var hasUser = await dbContext.UserTokens.AnyAsync(x =>
                x.AccessToken == request.AccessToken && x.IdentityToken == request.IdentityToken,
            cancellationToken: cancellationToken);

        if (!hasUser)
            throw new BadHttpRequestException("Invalid access or id tokens", (int)HttpStatusCode.BadRequest);
        
        var message = new HttpRequestMessage();
        message.Method = HttpMethod.Get;
        message.RequestUri =
            new Uri($"https://youtube.googleapis.com/youtube/v3/" +
                    $"search?part=snippet&forMine=true&maxResults=25&order=date&type=video&key=${request.AccessToken}");
        message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", request.AccessToken);
        message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        var response = await client.SendAsync(message, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new BadHttpRequestException("Unauthorized", (int)HttpStatusCode.Unauthorized);
        
        return await response.Content.ReadAsStringAsync(cancellationToken);
    }
}