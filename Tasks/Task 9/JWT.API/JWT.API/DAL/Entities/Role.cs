using JWT.API.DAL.BaseEntities;

namespace JWT.API.DAL.Entities;

public class Role : BaseEntity
{
    public string RoleName { get; set; }

    public List<User> Users { get; set; } = [];
}