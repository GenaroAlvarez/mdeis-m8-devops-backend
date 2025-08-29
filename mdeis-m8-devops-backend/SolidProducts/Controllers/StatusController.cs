using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidProducts.DTOs;

namespace SolidProducts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientResponseDto>>> GetStatus()
        {
            return Ok(new { Environment = "PROD", Status = "OK" });
        }
    }
}
