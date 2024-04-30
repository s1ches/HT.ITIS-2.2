using System.Text.Json.Serialization;

namespace OAuth.API.Models.GoogleResponseDTOs;

public class GetRefreshTokenDto
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
}