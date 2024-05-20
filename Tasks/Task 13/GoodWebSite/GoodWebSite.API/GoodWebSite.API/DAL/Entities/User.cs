using GoodWebSite.DAL.BaseEntities;

namespace GoodWebSite.DAL.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; }

    public string PasswordHash { get; set; }
}