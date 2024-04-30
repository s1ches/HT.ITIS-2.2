using System.Text.Json.Serialization;

namespace OAuth.API.Models.GoogleResponseDTOs;

public class GetAccessTokensDto
{
    [JsonPropertyName("id_token")]
    public string IdentityToken { get; set; }
}