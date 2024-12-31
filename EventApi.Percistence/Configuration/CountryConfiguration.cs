using EventApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventApi.Percistence.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasMany(p => p.Company).WithOne(c => c.Country);
            builder.HasMany(p => p.City).WithOne(c => c.Country).HasForeignKey(c=> c.CountryId);
        }

    }
}
