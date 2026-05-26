using BeautySalonExpolorer.BLL.DTOs;
using BeautySalonExpolorer.BLL.Interfaces;
using BeautySalonExpolorer.DAL.Entities;
using BeautySalonExpolorer.DAL.Interfaces;
using FluentValidation;

namespace BeautySalonExpolorer.BLL.Services;

public class SalonService : ISalonService
{
    private readonly ISalonRepository _salonRepo;
    private readonly IValidator<UpdateSalonDTO> _validator;
    public SalonService(ISalonRepository salonRepo, IValidator<UpdateSalonDTO> validator)
    {
        _salonRepo = salonRepo;   
        _validator = validator;
    }

    public async Task<SalonDTO?> GetSalonAsync(Guid id)
    {
        var salon = await _salonRepo.GetSalonAsync(id);

        if(salon == null) return null;
        
        return new SalonDTO
        {
            SalonId = salon.SalonId,
            Name = salon.Name,
            Street = salon.Street,
            District = salon.District,
            Phone = salon.Phone,
            Website = salon.Website,
            Rating = salon.Rating,
            ReviewsCount = salon.ReviewsCount,
            LocationUrl = salon.LocationUrl,
            Categories = salon.Categories
                .Select(sc => sc.Category.Name)
                .ToList()
        };
    }

    public async Task<IEnumerable<SalonListDTO>> GetSalonListAsync()
    {
        var businesses = await _salonRepo.GetSalonListAsync();
        
        return businesses.Select(s => new SalonListDTO
        {
            SalonId = s.SalonId,
            Name = s.Name,
            ShortAddress = $"{s.Street}, {s.District}",
            Rating = s.Rating,
            Categories = s.Categories
                .Select(sc => sc.Category.Name)
                .ToList()
        });
    }

    public async Task<bool> UpdateSalonAsync(Guid id, UpdateSalonDTO dto)
    {
        await _validator.ValidateAndThrowAsync(dto);

        var salon = await _salonRepo.GetSalonAsync(id);
        if (salon == null) return false;

        var existingCategories = await _salonRepo.GetCategoriesByNamesAsync(dto.Categories);
        if(existingCategories.Count != dto.Categories.Count)
        {
            throw new Exception("Bad request");
        }

        salon.Name = dto.Name ?? salon.Name;
        salon.Street = dto.Street ?? salon.Street;
        salon.District = dto.District ?? salon.District;
        salon.Phone = dto.Phone ?? salon.Phone;
        salon.Website = dto.Website ?? salon.Website;
        salon.LocationUrl = dto.LocationUrl ?? salon.LocationUrl;


        salon.Categories.Clear();
                
        foreach(var category in existingCategories)
        {
            salon.Categories.Add(new SalonCategory
            {
                SalonId = salon.SalonId,
                CategoryId = category.CategoryId,
            });
        }

        await _salonRepo.UpdateSalonAsync();
        return true;
    }
}