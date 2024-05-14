using Docker.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Docker.API.Interfaces;

public interface IAppDbContext
{
    DbSet<DockerEntity> DockerEntities { get; set; }
    
    DatabaseFacade Database { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}