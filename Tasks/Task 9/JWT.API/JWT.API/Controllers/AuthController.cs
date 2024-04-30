using System.Security.Claims;
using JWT.API.BaseConfigOptions;
using JWT.API.DAL.Entities;
using JWT.API.Interfaces;
using JWT.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWT.API.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class AuthController(IAppDbContext dbContext, IJwtGenerator jwtGenerator,
    IPasswordHasher<User> passwordHasher, IUserClaimsManager claimsManager) : ControllerBase
{
    [HttpPost("Login")]
    public async Task<AuthResponse> Login([FromBody] LoginModel model, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.UserName == model.UserName, cancellationToken: cancellationToken);

        if (user is null)
            throw new BadHttpRequestException($"User with name: {model.UserName} doesn't exist");
        
        if(passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password)
           is PasswordVerificationResult.Failed)
             throw new BadHttpRequestException($"Wrong password");
        
        var claims = claimsManager.GetUserClaims(user);
        
        var accessToken = jwtGenerator.GenerateAccessToken(claims);
        
        return new AuthResponse
        {
            AccessToken = accessToken,
            RoleNames = claims
                .Where(x => x.Type == ClaimTypes.Role)
                .Select(x => x.Value)
                .ToList()
        };
    }

    [HttpPost("Register")]
    public async Task<AuthResponse> Register([FromBody] RegisterModel model, CancellationToken cancellationToken)
    {
        var userWithSameNameExist = await dbContext.Users
            .Select(x => x.UserName)
            .AnyAsync(x => x == model.UserName, cancellationToken: cancellationToken);

        if (userWithSameNameExist)
            throw new BadHttpRequestException($"User with name: {model.UserName} already exist");

        var user = new User() {UserName = model.UserName};
        
        foreach (var roleName in model.RoleNames)
        {
            var role = await dbContext.Roles
                .FirstOrDefaultAsync(x => x.RoleName == roleName, cancellationToken: cancellationToken);

            if (role is null)
                throw new BadHttpRequestException($"Role with name: {roleName} doesn't exist");
            
            user.Roles.Add(role);
        }
        
        user.PasswordHash = passwordHasher.HashPassword(user, model.Password);
        
        await dbContext.Users.AddAsync(user, cancellationToken);
        var saveChangesResult = await dbContext.SaveChangesAsync(cancellationToken);

        if (saveChangesResult == 0)
            throw new Exception("Something went wrong");
        
        return await Login(new LoginModel{ UserName = model.UserName, Password = model.Password}, cancellationToken);
    }
}