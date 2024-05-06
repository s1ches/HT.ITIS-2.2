namespace Identity.API.DTOs.Auth.Login;

public class PostLoginRequest
{
    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;

    public bool RememberMe { get; set; } = false;
}