using JWT.API.DAL.BaseValues;
using JWT.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWT.API.DAL.EntityTypeConfigurations;

public class RoleTypeConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            BaseRoles.AdminRole,
            BaseRoles.UserRole
        );
    }
}