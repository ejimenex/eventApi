using EventApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventApi.Percistence.Configuration
{
    public class OcupationConfiguration : IEntityTypeConfiguration<Ocupation>
    {
        public void Configure(EntityTypeBuilder<Ocupation> builder)
        {
            builder.HasMany(p => p.Users).WithOne(c => c.Ocupation);
        }
    }
}
