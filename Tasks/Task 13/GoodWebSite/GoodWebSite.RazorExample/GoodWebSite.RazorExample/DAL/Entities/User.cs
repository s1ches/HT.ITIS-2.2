using GoodWebSite.RazorExample.DAL.BaseEntities;

namespace GoodWebSite.RazorExample.DAL.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; }

    public string PasswordHash { get; set; }
}