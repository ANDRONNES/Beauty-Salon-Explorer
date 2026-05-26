using BeautySalonExpolorer.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonExpolorer.DAL.Persistence.ModelConfigurations;

public class BusinessServiceConfiguration : IEntityTypeConfiguration<BusinessService>
{
    public void Configure(EntityTypeBuilder<BusinessService> builder)
    {
        builder.HasKey(bs => new { bs.BusinessId, bs.ServiceId });

        builder.Property(bs => bs.Price)
            .HasColumnType("decimal(10,2)");
    }
}