using Docker.API.DTOs;
using Docker.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Docker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DockerController(IAppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<GetDockerResponse> Get()
    {
        var result = await dbContext.DockerEntities.FirstOrDefaultAsync();
        return new GetDockerResponse
        {
            Message = result?.Message
        };
    }
}