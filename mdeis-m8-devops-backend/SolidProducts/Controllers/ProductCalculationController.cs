using Microsoft.AspNetCore.Mvc;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;

namespace SolidProducts.Controllers;

[ApiController]
[Route("api/v1/productCalculation")]
public class ProductCalculationController : ControllerBase
{
    private readonly IProductCalculationService _productCalculationService;
    public ProductCalculationController(IProductCalculationService productCalculationService) => _productCalculationService = productCalculationService;

    [HttpPost]
    public async Task<ActionResult<IEnumerable<ProductCalculationResponseDto>>> GetCalculatedProduct(ProductCalculationRequestDto request)
    {
        var productCalculation = await _productCalculationService.GetCalculatedProductAsync(request);
        return Ok(productCalculation);
    }
}
