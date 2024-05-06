using Identity.API.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Services.IdentityServices;

public class PasswordValidator : IPasswordValidator<User>
{
    private const string AllowedPasswordCharacters = "1234567890©®™•§†‡–—¶¡¿¢£Є¥:'\"|/\\;#№%^&*`~()<>,.[]{}+=-_";

    public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string? password)
        => Task.FromResult(
            password!.All(AllowedPasswordCharacters.Contains)
            && manager.Options.Password.RequiredLength <= password!.Length
                ? IdentityResult.Success
                : IdentityResult.Failed());
}