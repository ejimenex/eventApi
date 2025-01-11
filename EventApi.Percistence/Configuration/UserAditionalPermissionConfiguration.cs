using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EventApi.Percistence.Configuration.Constants;
using EventApi.Domain.Entities.Security;

namespace EventApi.Percistence.Configuration
{
    public class UserAditionalPermissionConfiguration : IEntityTypeConfiguration<UserAdittionalPermission>
    {
        public void Configure(EntityTypeBuilder<UserAdittionalPermission> builder)
        {
            builder.ToTable("UserAdittionalPermission", Schemas.Security);

            builder
                .HasOne(c => c.User)
                .WithMany(c => c.UserAdittionalPermission)
                .HasForeignKey(c=> c.UserId);

            builder
                .HasOne(c => c.Permission)
                .WithMany(c => c.UserAdittionalPermission)
                .HasForeignKey(c => c.PermissionId);
        }
    }
}