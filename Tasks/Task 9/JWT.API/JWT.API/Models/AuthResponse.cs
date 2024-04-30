namespace JWT.API.Models;

public class AuthResponse
{
    public string AccessToken { get; set; }
    
    public List<string> RoleNames { get; set; }
}