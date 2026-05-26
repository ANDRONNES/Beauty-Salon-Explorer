using BeautySalonExpolorer.DAL.Entities;

namespace BeautySalonExpolorer.DAL.Interfaces;

public interface ISalonRepository
{
    Task<IEnumerable<Salon>> GetSalonListAsync();  
}