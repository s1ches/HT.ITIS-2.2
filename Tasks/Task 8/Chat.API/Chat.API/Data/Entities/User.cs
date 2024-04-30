using Chat.API.Data.BaseEntities;

namespace Chat.API.Data.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    
    public List<Message> Messages { get; set; }
}