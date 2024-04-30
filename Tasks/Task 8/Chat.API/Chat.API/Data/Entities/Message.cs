using Chat.API.Data.BaseEntities;

namespace Chat.API.Data.Entities;

public class Message : BaseEntity
{
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    public string MessageContent { get; set; }
    
    public DateTime SendDate { get; set; }
}