using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EventApi.Percistence.Configuration.Constants;
using EventApi.Domain.Entities.Security;

namespace EventApi.Percistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", Schemas.Security);
            builder.HasMany(c => c.UserRole).WithOne(c => c.User);
        }
    }
}