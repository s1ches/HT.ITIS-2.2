namespace JWT.API.Models;

public class RegisterModel
{
    public string UserName { get; set; }
    
    public string Password { get; set; }
    
    public List<string> RoleNames { get; set; }
}