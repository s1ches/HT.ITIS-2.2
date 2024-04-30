using System.Text.Json.Serialization;

namespace OAuth.API.Data.Entities;

public class UserTokens
{
    [JsonIgnore]
    public Guid Id { get; set; }
    
    [JsonIgnore]
    public string Email { get; set; }
    
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
    
    [JsonIgnore]
    public DateTime CreateDate { get; set; }
    
    [JsonIgnore]
    public DateTime UpdateDate { get; set; }
    
    [JsonPropertyName("id_token")]
    public string IdentityToken { get; set; }
    
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }
}