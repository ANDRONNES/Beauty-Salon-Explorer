using System.Text.Json;
using BeautySalonExpolorer.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeautySalonExpolorer.DAL.Persistence.Seed;

public class DbInitializer
{
    public static async Task SeedDataAsync(AppDbContext context, string jsonFilePath)
    {
        if (!File.Exists(jsonFilePath))
        {
            Console.WriteLine("Seed Data failed. File not found.");
            return;
        }

        if (!await context.Salons.AnyAsync())
        {
            var jsonString = await File.ReadAllTextAsync(jsonFilePath);
            var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
            var salonDtos = JsonSerializer.Deserialize<List<SalonJsonDTO>>(jsonString, options);

            if(salonDtos == null || !salonDtos.Any())
            {
                Console.WriteLine("Error extracting data from json");
                return;
            } 
            
            var categoryCache = new Dictionary<string, Category>();

            foreach (var dto in salonDtos)
            {
                var salon = new Salon
                {
                    Name = dto.Title,
                    Street = dto.Street,
                    District = dto.District,
                    Phone = dto.Phone,
                    Website = dto.Website,
                    Rating = dto.TotalScore.HasValue ? (decimal) dto.TotalScore.Value : null,
                    ReviewsCount = dto.ReviewsCount.HasValue ? (int)dto.ReviewsCount.Value : null,
                    LocationUrl = dto.LocationUrl,
                };

                context.Add(salon);

                foreach (var categoryName in dto.Categories)
                {
                    if (string.IsNullOrWhiteSpace(categoryName)) continue;

                    if(!categoryCache.TryGetValue(categoryName, out var category))
                    {
                        category = await context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);

                        if (category == null)
                        {
                            category = new Category
                            {
                                Name = categoryName,
                            };
                            context.Add(category);
                        }
                        categoryCache[categoryName] = category;
                    }

                    var salonCategory = new SalonCategory
                    {
                        SalonId = salon.SalonId,
                        CategoryId = category.CategoryId
                    };
                    context.SalonsCategories.Add(salonCategory);
                }
            }

            await context.SaveChangesAsync();
            Console.WriteLine("Data seeded succsessfully");
        }
    }
}