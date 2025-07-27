using Microsoft.AspNetCore.Mvc;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;

namespace SolidProducts.Controllers;

[ApiController]
[Route("api/v1/clients")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientResponseDto>>> GetAll()
    {
        var clients = await _clientService.GetAllAsync();
        return Ok(clients);
    }

    [HttpPost]
    public async Task<ActionResult<ClientResponseDto>> Create(ClientRequestDto request)
    {
        var client = await _clientService.CreateAsync(request);
        return Ok(client);
    }
}