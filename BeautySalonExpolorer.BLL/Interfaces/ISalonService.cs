using BeautySalonExpolorer.BLL.DTOs;

namespace BeautySalonExpolorer.BLL.Interfaces;

public interface ISalonService
{
    Task<IEnumerable<SalonListDTO>> GetSalonListAsync();
    Task<SalonDTO?> GetSalonAsync(Guid id);
    Task<bool> UpdateSalonAsync(Guid id, UpdateSalonDTO dto);
}