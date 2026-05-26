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
    public async Task<IEnumerable<Salon>> GetSalonListAsync()
    {
        return await _context.Salons
            .Include(s => s.Categories)
            .ThenInclude(sc => sc.Category)
            .ToListAsync();
    }
}