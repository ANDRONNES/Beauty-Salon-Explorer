using BeautySalonExpolorer.DAL.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context; 

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNames()
    {
        var categories = await _context.Categories
            .Select(c => c.Name)
            .ToListAsync();

        return Ok(categories);
    }
}