using EventApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventApi.Percistence.Configuration
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.ToTable("Warehouse", "dbo");
            builder
                .HasOne(c => c.Activities);
               // .WithMany(c => c.Activities)
               // .HasForeignKey(c => c.StatusId);
        }

    }
}
