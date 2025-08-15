using Microsoft.AspNetCore.Mvc;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;
namespace SolidProducts.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService svc) => _productService = svc;

        // [HttpPost]
        // public async Task<ActionResult<ProductResponseDto>> Create(ProductRequestDto productRequestDto)
        // {
        //     var product = await _productService.CreateAsync(productRequestDto);
        //     return Ok(product);
        // }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }
    }
}
