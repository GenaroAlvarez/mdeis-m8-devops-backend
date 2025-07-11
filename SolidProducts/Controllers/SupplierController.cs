using Microsoft.AspNetCore.Mvc;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;

namespace SolidProducts.Controllers;

[ApiController]
[Route("api/v1/suplier")]
public class SupplierController : ControllerBase
{
    private readonly IProductService _productService;
    public SupplierController(IProductService svc) => _productService = svc;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SupplierResponseDto>>> GetAll()
    {
        var suppliers = await _productService.GetAllSupplierAsync();
        return Ok(suppliers);
    }
}
