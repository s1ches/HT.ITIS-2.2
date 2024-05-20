using GoodWebSite.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodWebSite.Interfaces;

public interface IAppDbContext
{
    DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}