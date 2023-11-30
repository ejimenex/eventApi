using EventApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventApi.Percistence.Configuration
{
    public class ActivitiesConfiguration : IEntityTypeConfiguration<Activities>
    {
        public void Configure(EntityTypeBuilder<Activities> builder)
        {
            builder.ToTable("Activities", "dbo");
            builder
                .HasOne(c => c.Statu)
                .WithMany(c => c.Activities)
                .HasForeignKey(c=> c.StatusId);
        }

    }
}
