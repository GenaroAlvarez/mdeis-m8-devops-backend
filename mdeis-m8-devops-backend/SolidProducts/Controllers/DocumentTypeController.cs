using Microsoft.AspNetCore.Mvc;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;

[ApiController]
[Route("api/v1/document-types")]
public class DocumentTypeController : ControllerBase
{
    private readonly IDocumentTypeService _service;
    
    public DocumentTypeController(IDocumentTypeService service) => _service = service;
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DocumentTypeResponseDto>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }
}