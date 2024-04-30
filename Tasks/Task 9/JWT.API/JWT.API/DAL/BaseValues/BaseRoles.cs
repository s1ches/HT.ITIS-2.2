using JWT.API.DAL.Entities;

namespace JWT.API.DAL.BaseValues;

public static class BaseRoles
{
    public static readonly Guid AdminRoleId = new("EFDA41E4-FA23-4EC6-8CFD-3BCC0795F9D3");

    public const string AdminRoleName = "Admin";
    
    public static readonly Guid UserRoleId = new ("B5971C6F-285C-423F-93BF-18533A908B28");

    public const string UserRoleName = "User";
    
    public static readonly Role AdminRole = new Role
    {
        Id = AdminRoleId,
        RoleName = AdminRoleName
    };

    public static readonly Role UserRole = new Role
    {
        Id = UserRoleId,
        RoleName = UserRoleName
    };
}