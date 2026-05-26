using BeautySalonExpolorer.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonExpolorer.DAL.Persistence.ModelConfigurations;

public class BusinessConfiguration : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder.HasKey(b => b.BusinessId); 

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Street)
            .HasMaxLength(100);

        builder.Property(b => b.District)
            .HasMaxLength(50);

        builder.Property(b => b.Phone)
            .HasMaxLength(30)
            .IsRequired(false); 

        builder.Property(b => b.Website)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(b => b.Rating)
            .HasColumnType("decimal(2,1)")
            .IsRequired(false);
            
        builder.Property(b => b.LocationUrl)
            .HasMaxLength(500)
            .IsRequired(false);
    }
}