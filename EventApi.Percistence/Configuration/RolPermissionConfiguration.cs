using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EventApi.Percistence.Configuration.Constants;
using EventApi.Domain.Entities.Security;

namespace EventApi.Percistence.Configuration
{
    public class RolPermissionConfiguration : IEntityTypeConfiguration<RolPermission>
    {
        public void Configure(EntityTypeBuilder<RolPermission> builder)
        {
            builder
                .ToTable("RolPermission", Schemas.Security);

            builder
                .HasOne(c => c.Permission)
                .WithMany (c=> c.RolPermission)
                .HasForeignKey(c=> c.PermissionId);

            builder
                .HasOne(c => c.Role)
                .WithMany(c => c.RolPermission)
                .HasForeignKey(c => c.RolId);
        }
    }
}