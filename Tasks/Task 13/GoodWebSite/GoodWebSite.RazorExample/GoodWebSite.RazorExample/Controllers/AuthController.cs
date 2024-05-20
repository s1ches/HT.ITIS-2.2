using GoodWebSite.RazorExample.DAL.Entities;
using GoodWebSite.RazorExample.Interfaces;
using GoodWebSite.RazorExample.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodWebSite.RazorExample.Controllers;

[Controller]
[AllowAnonymous]
[Route("[controller]/[action]")]
public class AuthController(
    IAppDbContext dbContext,
    ISignInManager signInManager) : Controller
{
    [HttpGet]
    public IActionResult Login() => View(new LoginViewModel());

    [HttpPost]
    public async Task<IActionResult> Login([FromForm] LoginViewModel model, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .FirstOrDefaultAsync(x => x.UserName == model.UserName, cancellationToken);

        if (user is null)
        {
            ModelState.AddModelError(nameof(model.UserName),
                $"User with name: {model.UserName} was not found");
            return View(model);
        }

        var canSignIn = signInManager.TryPasswordSignIn(user, model.Password, model.IsPersistent);

        if (!canSignIn)
        {
            ModelState.AddModelError(nameof(model.Password),
                $"User with name: {model.UserName} was not found");
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Register() => View(new RegisterViewModel());

    [HttpPost]
    public async Task<IActionResult> Register(
        [FromForm] RegisterViewModel model,
        CancellationToken cancellationToken,
        [FromServices] IPasswordHasher<User> passwordHasher)
    {
        var userWithSameNameExist = await dbContext.Users
            .Select(x => x.UserName)
            .AnyAsync(x => x == model.UserName, cancellationToken: cancellationToken);

        if (userWithSameNameExist)
        {
            ModelState.AddModelError(nameof(model.UserName),
                $"User with name: {model.UserName} was not found");
            return View(model);
        }

        var user = new User() { UserName = model.UserName };

        user.PasswordHash = passwordHasher.HashPassword(user, model.Password);

        await dbContext.Users.AddAsync(user, cancellationToken);
        var saveChangesResult = await dbContext.SaveChangesAsync(cancellationToken);

        if (saveChangesResult == 0)
            throw new BadHttpRequestException("Something went wrong");

        var loginRequest = new LoginViewModel
        {
            Password = model.Password,
            UserName = model.UserName,
            IsPersistent = false
        };

        return await Login(loginRequest, cancellationToken);
    }
}