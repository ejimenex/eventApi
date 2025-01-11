using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EventApi.Percistence.Configuration.Constants;
using EventApi.Domain.Entities.Security;

namespace EventApi.Percistence.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder
                .ToTable("UserRole", Schemas.Security);

            builder
                .HasOne(c => c.User)
                .WithMany (c=> c.UserRole)
                .HasForeignKey(c=> c.UserId);

            builder
                .HasOne(c => c.Role)
                .WithMany(c => c.UserRole)
                .HasForeignKey(c => c.RolId);
        }
    }
}