using BeautySalonExpolorer.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonExpolorer.DAL.Persistence.ModelConfigurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(s => s.ServiceId);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}