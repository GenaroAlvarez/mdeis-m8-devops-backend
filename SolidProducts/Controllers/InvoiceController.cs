using Microsoft.AspNetCore.Mvc;
using SolidProducts.DTOs;
using SolidProducts.Entities;
using SolidProducts.Interfaces;

namespace SolidProducts.Controllers
{
    [ApiController]
    [Route("api/v1/invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService) => _invoiceService = invoiceService;

        [HttpPost]
        public async Task<ActionResult<Invoice>> Create(InvoiceRequestDto invoiceRequestDto) {
            var invoice = await _invoiceService.CreateAsync(invoiceRequestDto);
            System.Console.WriteLine(invoice);
            return Ok(invoice);
        }
        // public async Task<ActionResult<ProductResponseDto>> Create(ProductRequestDto productRequestDto)
        // {
        //     var product = await _productService.CreateAsync(productRequestDto);
        //     return Ok(product);
        // }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAll()
        // {
        //     var products = await _productService.GetAllAsync();
        //     return Ok(products);
        // }
    }
}
