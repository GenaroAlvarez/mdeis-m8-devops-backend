// using Microsoft.AspNetCore.Mvc;
// using SolidProducts.DTOs;
// using SolidProducts.Interfaces;

// namespace SolidProducts.Controllers;

// [ApiController]
// [Route("api/v1/supliers")]
// public class SupplierController : ControllerBase
// {
//     private readonly ISupplierService _supplierService;
//     public SupplierController(ISupplierService supplierService) => _supplierService = supplierService;

//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<SupplierResponseDto>>> GetAll()
//     {
//         var suppliers = await _supplierService.GetAllAsync();
//         return Ok(suppliers);
//     }
// }
