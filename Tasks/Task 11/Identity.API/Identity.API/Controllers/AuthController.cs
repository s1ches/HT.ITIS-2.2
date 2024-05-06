using System.Net;
using Identity.API.Constants;
using Identity.API.DAL.Entities;
using Identity.API.DTOs.Auth.ConfirmEmail;
using Identity.API.DTOs.Auth.Login;
using Identity.API.DTOs.Auth.Register;
using Identity.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthController(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    IEmailSender emailSender,
    ITemplateMessageBuilder messageBuilder) : ControllerBase
{
    [HttpPost("Login")]
    public async Task Login(
        [FromBody] PostLoginRequest request,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null)
            throw new BadHttpRequestException($"User with email: {request.Email} was not found",
                (int)HttpStatusCode.BadRequest);

        if (!user.EmailConfirmed)
        {
            await SendConfirmEmailMessageAsync(user, cancellationToken);
            throw new BadHttpRequestException($"Need confirm email address {request.Email}",
                (int)HttpStatusCode.BadRequest);
        }

        var signInResult = await signInManager.PasswordSignInAsync(user,
            request.Password, 
            request.RememberMe, 
            false);

        if (!signInResult.Succeeded)
            throw new BadHttpRequestException("Wrong password", (int)HttpStatusCode.BadRequest);
    }

    [HttpPost("Register")]
    public async Task Register([FromBody] PostRegisterRequest request,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is not null)
            throw new BadHttpRequestException($"User with same email already register",
                (int)HttpStatusCode.BadRequest);

        user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };

        var createUserResult = await userManager.CreateAsync(user, request.Password);
        
        if (!createUserResult.Succeeded)
            throw new BadHttpRequestException(
                string.Join('\n', createUserResult.Errors.Select(x => $"{x.Code} : {x.Description}")),
                (int)HttpStatusCode.BadRequest);
        
        await SendConfirmEmailMessageAsync(user, cancellationToken);
    }
    
    [HttpPost("ConfirmEmail")]
    public async Task ConfirmEmail([FromBody] PostConfirmEmailRequest request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        
        if(user is null)
            throw new BadHttpRequestException($"User with email: {request.Email} was not found",
            (int)HttpStatusCode.BadRequest);

        await userManager.ConfirmEmailAsync(user, request.EmailConfirmationCode);
    }

    private async Task SendConfirmEmailMessageAsync(User user, CancellationToken cancellationToken)
    {
        var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
        var message = await messageBuilder.BuildTemplate(MessageTemplateType.ConfirmEmailMessage,
            cancellationToken,
            [user.UserName!, confirmationToken]);
        await emailSender.SendEmailAsync(user.Email!, message, cancellationToken);
    }
}