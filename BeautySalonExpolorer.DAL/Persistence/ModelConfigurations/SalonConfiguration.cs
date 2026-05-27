using BeautySalonExpolorer.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonExpolorer.DAL.Persistence.ModelConfigurations;

public class BusinessConfiguration : IEntityTypeConfiguration<Salon>
{
    public void Configure(EntityTypeBuilder<Salon> builder)
    {
        builder.HasKey(s => s.SalonId);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(s => s.Street)
            .HasMaxLength(100);

        builder.Property(s => s.District)
            .HasMaxLength(50);

        builder.Property(s => s.Phone)
            .HasMaxLength(30)
            .IsRequired(false);

        builder.Property(s => s.Website)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(s => s.Rating)
            .HasColumnType("decimal(2,1)")
            .IsRequired(false);

        builder.Property(s => s.LocationUrl)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(s => s.ImageUrl)
            .HasMaxLength(500);
    }
}