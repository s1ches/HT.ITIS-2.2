namespace OAuth.API.Models.DTOs.PostRefreshToken;

public class PostRefreshTokenRequest
{
    public string Email { get; set; }
    
    public string AccessToken { get; set; }
}