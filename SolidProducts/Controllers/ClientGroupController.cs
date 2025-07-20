using Microsoft.AspNetCore.Mvc;
using SolidProducts.DTOs;
using SolidProducts.Interfaces;

namespace SolidProducts.Controllers;

[ApiController]
[Route("api/v1/client-groups")]
public class ClientGroupController : ControllerBase
{
    private readonly IClientGroupService _clientGroupService;

    public ClientGroupController(IClientGroupService clientGroupService)
    {
        _clientGroupService = clientGroupService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientGroupsResponseDto>>> GetAll()
    {
        //print something to the console for logging
        Console.WriteLine("Getting all client groups");
        var clientGroups = await _clientGroupService.GetAllAsync();
        return Ok(clientGroups);
    }
}