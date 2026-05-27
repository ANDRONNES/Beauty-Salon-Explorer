using BeautySalonExpolorer.DAL.Interfaces;
using BeautySalonExpolorer.DAL.Persistence;
using BeautySalonExpolorer.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BeautySalonExpolorer.DAL.Persistence.Seed;

namespace Microsoft.Extensions.DependencyInjection;

public static class DataAccessExtension
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention();
        });

        services.AddScoped<ISalonRepository, SalonRepository>();

        return services;
    }

    public static async Task InitializeDatabaseAsync(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<AppDbContext>();
                await context.Database.MigrateAsync();
                string jsonPath = Path.Combine(AppContext.BaseDirectory, "final.json");
                if (!File.Exists(jsonPath)) jsonPath = "final.json";

                await DbInitializer.SeedDataAsync(context, jsonPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                throw;
            }
        }
    }
}