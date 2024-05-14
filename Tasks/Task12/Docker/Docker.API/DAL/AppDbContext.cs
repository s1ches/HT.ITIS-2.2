using Docker.API.DAL.Entities;
using Docker.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Docker.API.DAL;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DockerEntity>().HasData(new List<DockerEntity>()
        {
            new ()
            {
                Id = new Guid("42D3536B-97E9-43DE-97AA-8E22DEFC0B94"),
                Message = "I ❤️ Docker, Docker secret is https://ibb.co/hZQghy0"
            }
        });
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<DockerEntity> DockerEntities { get; set; }
}