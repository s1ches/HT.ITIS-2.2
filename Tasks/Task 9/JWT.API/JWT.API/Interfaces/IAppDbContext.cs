using JWT.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWT.API.Interfaces;

public interface IAppDbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Role> Roles { get; set; }
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}