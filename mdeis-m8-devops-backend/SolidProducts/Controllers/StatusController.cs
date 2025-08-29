using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidProducts.DTOs;

namespace SolidProducts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        public readonly string Environment;

        public StatusController(IConfiguration _configuration)
        {
            Environment = _configuration.GetValue<string>("Env") ?? "ENV";
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClientResponseDto>> GetStatus()
        {
            return Ok(new { Environment, Status = "OK" });
        }
    }
}
