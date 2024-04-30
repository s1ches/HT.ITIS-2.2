using Chat.API.DTOs;
using Chat.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chat.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController(IChatHistoryService chatHistory) : ControllerBase
{
    [HttpGet]
    public async Task<IQueryable<MessageDto>> GetAllMessages(CancellationToken cancellationToken)
    {
        return chatHistory.GetChatHistory()
            .Select(x => new MessageDto()
            {
                UserName = x.User.Name,
                MessageContent = x.MessageContent
            });
    }
}