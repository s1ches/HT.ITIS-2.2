using Microsoft.AspNetCore.Mvc;

namespace BadWebSite.RazorExample.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}