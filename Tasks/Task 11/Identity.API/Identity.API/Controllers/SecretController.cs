using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecretController: ControllerBase
{
    [Authorize]
    [HttpGet("GetSecretKey")]
    public string GetSecretKey() 
        => "Follow link to see the amazing secret of all world: https://ibb.co/hZQghy0";
}