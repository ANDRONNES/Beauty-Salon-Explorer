using BeautySalonExpolorer.BLL.DTOs;
using BeautySalonExpolorer.BLL.Interfaces;
using BeautySalonExpolorer.DAL.Interfaces;

namespace BeautySalonExpolorer.BLL.Services;

public class SalonService : ISalonService
{
    private readonly ISalonRepository _salonRepo;
    public SalonService(ISalonRepository salonRepo)
    {
        _salonRepo = salonRepo;   
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
}