using Chat.API.Data;
using Chat.API.Data.Entities;
using Chat.API.DTOs;
using Chat.API.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Chat.API.Hubs;

public class ChatHub(ChatDbContext dbContext, IChatHistoryService chatHistoryService) : Hub
{
    public async Task JoinRoom(JoinUserDto user)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, "General");

        User connectedUser;

        if (!dbContext.Users.Any(x => x.Name == user.UserName))
        {
            var newUser = new User { Name = user.UserName };
            connectedUser = (await dbContext.AddAsync(newUser)).Entity;
            await dbContext.SaveChangesAsync();
        }
        else
            connectedUser = await dbContext.Users.AsNoTracking().FirstAsync(x => x.Name == user.UserName);

        foreach (var message in chatHistoryService.GetChatHistory())
            await Clients.Client(Context.ConnectionId)
                .SendAsync("ReceiveMessage", message.User.Name, message.MessageContent, message.Id);
    }

    public async Task SendMessage(MessageDto message)
    {
        var user = await dbContext.Users.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name == message.UserName);
        
        var newMessage = new Message
        {
            UserId = user!.Id,
            MessageContent = message.MessageContent,
            SendDate = DateTime.UtcNow
        };

        var createdMessage = await dbContext.AddAsync(newMessage);
        await dbContext.SaveChangesAsync();
        
        await Clients.All
            .SendAsync("ReceiveMessage", message.UserName,
                message.MessageContent, createdMessage.Entity.Id);
    }
}