using BeautySalonExpolorer.BLL.DTOs;
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

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var salon = await _salonService.GetSalonAsync(id);
        return Ok(salon);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateById([FromRoute] Guid id,[FromBody] UpdateSalonDTO dto )
    {
        var isUpdated = await _salonService.UpdateSalonAsync(id, dto);
        return isUpdated? NoContent() : NotFound();
    }
}