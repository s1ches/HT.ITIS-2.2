using Microsoft.EntityFrameworkCore;
using OAuth.API.Data.Entities;

namespace OAuth.API.Interfaces;

public interface IAppDbContext
{
    DbSet<UserTokens> UserTokens { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}