using Identity.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Interfaces;

public interface IAppDbContext
{ 
    DbSet<User> Users { get; set; }
    
    DbSet<Role> Roles { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}