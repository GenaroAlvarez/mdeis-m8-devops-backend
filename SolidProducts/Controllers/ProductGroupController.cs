using Microsoft.AspNetCore.Mvc;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;

namespace SolidProducts.Controllers;

public class ProductGroupController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductGroupController(IProductService svc) => _productService = svc;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ManufacturerResponseDto>>> GetAll()
    {
        var productGroups = await _productService.GetAllProductGroupsAsync();
        return Ok(productGroups);
    }
}
