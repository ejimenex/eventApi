using EventApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventApi.Percistence.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
                .HasMany(p => p.Activities)
                .WithOne(c => c.City)
                .HasForeignKey(c=> c.CityId);

            builder
          .HasOne(p => p.Country)
          .WithMany(c => c.City)
          .HasForeignKey(c => c.CountryId);
        }

    }
}
