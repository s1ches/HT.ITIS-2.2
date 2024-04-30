using System.Text.Json.Serialization;

namespace OAuth.API.Models.GoogleResponseDTOs;

public class UserTokensDto
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
    
    [JsonPropertyName("id_token")]
    public string IdentityToken { get; set; }
    
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }
}