using System.Text.Json.Serialization;

namespace OAuth.API.Models.DTOs.OAuth.GoogleResponseDTOs;

public class GetRefreshTokenDto
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
}