using Chat.API.Data;
using Chat.API.Data.Entities;
using Chat.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chat.API.Services;

public class ChatHistoryService(ChatDbContext dbContext) : IChatHistoryService
{
    public IQueryable<Message> GetChatHistory()
        => dbContext.Messages
            .AsNoTracking().Include(x => x.User)
            .OrderBy(x => x.SendDate);
}