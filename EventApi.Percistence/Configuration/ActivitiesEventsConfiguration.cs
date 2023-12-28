using EventApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventApi.Percistence.Configuration
{
    public class ActivitiesEventsConfiguration : IEntityTypeConfiguration<ActivitiesEvents>
    {
        public void Configure(EntityTypeBuilder<ActivitiesEvents> builder)
        {
            builder.ToTable("ActivitiesEvents", "dbo");
            builder
                .HasOne(c => c.Statu)
                .WithMany(c => c.ActivitiesEvents)
                .HasForeignKey(c => c.StatusId);
        }

    }
}
