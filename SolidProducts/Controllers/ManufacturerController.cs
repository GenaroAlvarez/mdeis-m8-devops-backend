using Microsoft.AspNetCore.Mvc;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;

namespace SolidProducts.Controllers;

public class ManufacturerController : ControllerBase
{
    private readonly IProductService _productService;
    public ManufacturerController(IProductService svc) => _productService = svc;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ManufacturerResponseDto>>> GetAll()
    {
        var manufacturers = await _productService.GetAllManufacturersAsync();
        return Ok(manufacturers);
    }
}