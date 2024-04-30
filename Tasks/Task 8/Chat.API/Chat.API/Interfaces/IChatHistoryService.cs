using Chat.API.Data.Entities;

namespace Chat.API.Interfaces;

public interface IChatHistoryService
{
    public IQueryable<Message> GetChatHistory();
}