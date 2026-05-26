using BeautySalonExpolorer.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeautySalonExpolorer.DAL.Persistence;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<Business> Businesses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<BusinessService> BusinessServices { get; set; }
    public DbSet<BusinessCategory> BusinessCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //applying configurations on every model
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        foreach(var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.DisplayName().ToLower());
        }
    }
}