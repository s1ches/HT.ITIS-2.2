using JWT.API.DAL.Entities;
using JWT.API.DAL.EntityTypeConfigurations;
using JWT.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JWT.API.DAL;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Role> Roles { get; set; }

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new RoleTypeConfiguration());
        
        base.OnModelCreating(builder);
    }
}