using Microsoft.EntityFrameworkCore;
using OAuth.API.Data.Entities;
using OAuth.API.Interfaces;

namespace OAuth.API.Data;

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
        modelBuilder.Entity<UserTokens>().HasKey(x => x.Id);
        modelBuilder.Entity<UserTokens>().HasIndex(x => x.Email);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<UserTokens> UserTokens { get; set; }
}