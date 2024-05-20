using GoodWebSite.DAL.Entities;
using GoodWebSite.DTOs.Auth.PostLogin;
using GoodWebSite.DTOs.Auth.PostRegister;
using GoodWebSite.Exceptions;
using GoodWebSite.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodWebSite.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/[controller]")]
public class AuthController(
    IAppDbContext dbContext,
    ISignInManager signInManager) : ControllerBase
{
    [HttpPost("Login")]
    public async Task Login([FromBody] PostLoginRequest request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);

        if (user is null)
            throw new BadRequestException($"User with name: {request.UserName} doesn't exist");

        var canSignIn = signInManager.TryPasswordSignIn(user, request.Password, request.IsPersistent);

        if (!canSignIn)
            throw new BadRequestException("Wrong password"); 
    }

    [HttpPost("Register")]
    public async Task Register(
        [FromBody] PostRegisterRequest request,
        CancellationToken cancellationToken,
        [FromServices] IPasswordHasher<User> passwordHasher)
    {
        var userWithSameNameExist = await dbContext.Users
            .Select(x => x.UserName)
            .AnyAsync(x => x == request.UserName, cancellationToken: cancellationToken);

        if (userWithSameNameExist)
            throw new BadRequestException($"User with name: {request.UserName} already exist");

        var user = new User() { UserName = request.UserName };

        user.PasswordHash = passwordHasher.HashPassword(user, request.Password);

        await dbContext.Users.AddAsync(user, cancellationToken);
        var saveChangesResult = await dbContext.SaveChangesAsync(cancellationToken);

        if (saveChangesResult == 0)
            throw new InternalServerErrorException("Something went wrong");

        var loginRequest = new PostLoginRequest
        {
            Password = request.Password,
            UserName = request.UserName,
            IsPersistent = false
        };

        await Login(loginRequest, cancellationToken);
    }
}