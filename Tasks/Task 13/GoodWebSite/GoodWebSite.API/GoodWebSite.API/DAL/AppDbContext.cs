using GoodWebSite.DAL.Entities;
using GoodWebSite.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoodWebSite.DAL;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public AppDbContext()
    {
    }
    
    public DbSet<User> Users { get; set; }
}