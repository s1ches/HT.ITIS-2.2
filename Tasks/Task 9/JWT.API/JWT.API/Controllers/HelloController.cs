using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet("HelloAdmin")]
    [Authorize(Roles = "Admin")]
    public string GetHelloAdmin() => "Hello, Admin🫅";

    [HttpGet("HelloUser")]
    [Authorize(Roles = "User")]
    public string GetHelloUser() => "Hello, User!";
}