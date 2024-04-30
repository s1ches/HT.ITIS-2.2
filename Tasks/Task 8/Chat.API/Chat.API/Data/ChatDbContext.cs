using Chat.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.API.Data;

public class ChatDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Message> Messages { get; set; }

    public ChatDbContext()
    {
    }
    
    public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
    { }
}