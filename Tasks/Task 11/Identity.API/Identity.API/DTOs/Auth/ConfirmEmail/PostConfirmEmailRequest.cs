namespace Identity.API.DTOs.Auth.ConfirmEmail;

public class PostConfirmEmailRequest
{
    public string Email { get; set; }
    
    public string EmailConfirmationCode { get; set; } = default!;
}