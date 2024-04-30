namespace OAuth.API.Models.DTOs.YouTube.GetMyVideos;

public class PostGetMyVideosRequest
{
    public string IdentityToken { get; set; }
    
    public string AccessToken { get; set; }
}