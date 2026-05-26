using BeautySalonExpolorer.DAL.Entities;

namespace BeautySalonExpolorer.DAL.Interfaces;

public interface ISalonRepository
{
    Task<IEnumerable<Salon>> GetSalonListAsync(); 
    Task<Salon?> GetSalonAsync(Guid id);  
    Task UpdateSalonAsync();

    Task<List<Category>> GetCategoriesByNamesAsync(List<string> categoryNames);


}