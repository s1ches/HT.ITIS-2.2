namespace OAuth.API.Models.DTOs.OAuth.PostRefreshToken;

public class PostRefreshTokenRequest
{
    public string Email { get; set; }
    
    public string AccessToken { get; set; }
}