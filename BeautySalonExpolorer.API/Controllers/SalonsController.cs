using BeautySalonExpolorer.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalonExpolorer.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class SalonsController : ControllerBase
{
    private readonly ISalonService _salonService;
    public SalonsController(ISalonService salonService) => _salonService = salonService;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var salons = await _salonService.GetSalonListAsync();
        return Ok(salons);
    }
}