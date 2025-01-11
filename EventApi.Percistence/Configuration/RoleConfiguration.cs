using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EventApi.Percistence.Configuration.Constants;
using EventApi.Domain.Entities.Security;

namespace EventApi.Percistence.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .ToTable("Role", Schemas.Security);

            builder
                .HasMany(c => c.UserRole)
                .WithOne(c => c.Role);

            builder
                .HasMany(c => c.RolPermission)
                .WithOne(c => c.Role);
        }
    }
}