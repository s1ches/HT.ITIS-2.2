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
        SecretMessage = "https://ibb.co/hZQghy0"
    };
}