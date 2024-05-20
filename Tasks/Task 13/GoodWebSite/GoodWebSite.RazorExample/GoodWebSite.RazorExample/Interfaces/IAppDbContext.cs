using GoodWebSite.RazorExample.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoodWebSite.RazorExample.Interfaces;

public interface IAppDbContext
{
    DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}