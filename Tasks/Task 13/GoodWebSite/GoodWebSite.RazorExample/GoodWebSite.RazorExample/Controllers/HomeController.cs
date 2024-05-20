using GoodWebSite.RazorExample.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodWebSite.RazorExample.Controllers;

[Authorize]
[Controller]
public class HomeController: Controller
{
    public IActionResult Index() => View(new IndexViewModel
    {
        SecretMessage = "https://ibb.co/hZQghy0"
    });
}