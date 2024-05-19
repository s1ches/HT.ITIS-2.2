namespace GoodWebSite.DTOs.Auth.PostLogin;

public class PostLoginRequest
{
    public string UserName { get; set; }

    public string Password { get; set; }
    
    public bool IsPersistent { get; set; }
}