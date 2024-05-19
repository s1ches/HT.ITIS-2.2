using GoodWebSite.DTOs.Secret.GetSecret;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodWebSite.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class SecretController : ControllerBase
{
    [HttpGet("GetSecret")]
    public GetSecretResponse GetSecret() => new()
    {
        SecretMessage = "Follow link to see the amazing secret of all world: https://ibb.co/hZQghy0"
    };
}