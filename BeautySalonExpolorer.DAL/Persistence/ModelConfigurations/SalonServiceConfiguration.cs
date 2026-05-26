using BeautySalonExpolorer.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonExpolorer.DAL.Persistence.ModelConfigurations;

public class BusinessServiceConfiguration : IEntityTypeConfiguration<SalonService>
{
    public void Configure(EntityTypeBuilder<SalonService> builder)
    {
        builder.HasKey(ss => new { ss.SalonId, ss.ServiceId });

        builder.Property(ss => ss.Price)
            .HasColumnType("decimal(10,2)");
    }
}