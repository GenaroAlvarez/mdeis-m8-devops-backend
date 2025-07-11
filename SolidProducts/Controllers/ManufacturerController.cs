using Microsoft.AspNetCore.Mvc;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;

namespace SolidProducts.Controllers;

[ApiController]
[Route("api/v1/manufacturers")]
public class ManufacturerController : ControllerBase
{
    private readonly IManufacturerService _manufacturerService;
    public ManufacturerController(IManufacturerService manufacturerService) => _manufacturerService = manufacturerService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ManufacturerResponseDto>>> GetAll()
    {
        var manufacturers = await _manufacturerService.GetAllAsync();
        return Ok(manufacturers);
    }
}