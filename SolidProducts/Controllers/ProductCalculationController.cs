using Microsoft.AspNetCore.Mvc;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;

namespace SolidProducts.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductCalculationController : ControllerBase
{
    private readonly IProductCalculationService _productCalculationService;
    public ProductCalculationController(IProductCalculationService productCalculationService) => _productCalculationService = productCalculationService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductCalculationResponseDto>>> GetCalculatedProduct(ProductCalculationRequestDto request)
    {
        var productCalculation = await _productCalculationService.GetCalculatedProductAsync(request);
        return Ok(productCalculation);
    }
}
