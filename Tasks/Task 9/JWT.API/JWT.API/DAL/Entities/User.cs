using JWT.API.DAL.BaseEntities;

namespace JWT.API.DAL.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; }
    
    public string PasswordHash { get; set; }
    
    public List<Role> Roles { get; set; } = [];
}