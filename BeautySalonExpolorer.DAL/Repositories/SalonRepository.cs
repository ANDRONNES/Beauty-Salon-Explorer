using BeautySalonExpolorer.DAL.Entities;
using BeautySalonExpolorer.DAL.Interfaces;
using BeautySalonExpolorer.DAL.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BeautySalonExpolorer.DAL.Repositories;

public class SalonRepository : ISalonRepository
{
    private readonly AppDbContext _context;

    public SalonRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetCategoriesByNamesAsync(List<string> categoryNames)
    {
        return await _context.Categories
            .Where(c => categoryNames.Contains(c.Name))
            .ToListAsync();
    }

    public async Task<Salon?> GetSalonAsync(Guid id)
    {
        return await _context.Salons
            .Include(sc => sc.Categories)
                .ThenInclude(c => c.Category)
            .FirstOrDefaultAsync(s => s.SalonId == id);
    }

    public async Task<IEnumerable<Salon>> GetSalonListAsync()
    {
        return await _context.Salons
            .Include(s => s.Categories)
            .ThenInclude(sc => sc.Category)
            .ToListAsync();
    }

    public async Task UpdateSalonAsync()
    {
        await _context.SaveChangesAsync();
    }
}