using GoodWebSite.RazorExample.DAL.Entities;
using GoodWebSite.RazorExample.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoodWebSite.RazorExample.DAL;

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