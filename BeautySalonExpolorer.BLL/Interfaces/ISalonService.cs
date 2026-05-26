using BeautySalonExpolorer.BLL.DTOs;

namespace BeautySalonExpolorer.BLL.Interfaces;

public interface ISalonService
{
    Task<IEnumerable<SalonListDTO>> GetSalonListAsync();
}