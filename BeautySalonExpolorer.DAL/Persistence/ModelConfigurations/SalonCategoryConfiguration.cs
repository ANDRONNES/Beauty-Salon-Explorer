using BeautySalonExpolorer.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonExpolorer.DAL.Persistence.ModelConfigurations;

public class BusinessCategoryConfiguration : IEntityTypeConfiguration<SalonCategory>
{
    public void Configure(EntityTypeBuilder<SalonCategory> builder)
    {
        builder.HasKey(sc => new { sc.SalonId, sc.CategoryId });
    }
}