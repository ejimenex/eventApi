using EventApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventApi.Percistence.Configuration
{
    public class StatuConfiguration : IEntityTypeConfiguration<Statu>
    {
        public void Configure(EntityTypeBuilder<Statu> builder)
        {
            builder.ToTable("Statu", "Catalog");
            builder.HasMany(c => c.Activities).WithOne(c => c.Statu);
            builder.HasMany(c => c.ActivitiesEvents).WithOne(c => c.Statu);
        }

    }
}
