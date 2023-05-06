using Microsoft.AspNetCore.Mvc;

namespace WebApiBackgroudServices.Controllers
{
    [ApiController]
    [Route("api/healthcheck")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"{DateTime.UtcNow:o}");
        }
    }
}