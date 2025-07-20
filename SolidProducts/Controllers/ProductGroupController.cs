// using Microsoft.AspNetCore.Mvc;
// using SolidProducts.DTOs;
// using SolidProducts.Interfaces;
// using SolidProducts.Services;

// namespace SolidProducts.Controllers;

// [ApiController]
// [Route("api/v1/productgroups")]
// public class ProductGroupController : ControllerBase
// {
//     private readonly IProductGroupService _productGroupService;
//     public ProductGroupController(IProductGroupService productGroupService) => _productGroupService = productGroupService;

//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<ManufacturerResponseDto>>> GetAll()
//     {
//         var productGroups = await _productGroupService.GetAllAsync();
//         return Ok(productGroups);
//     }
// }
