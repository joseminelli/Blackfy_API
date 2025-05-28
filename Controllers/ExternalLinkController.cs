using blackfy_API.Models;
using blackfy_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace blackfy_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalLinkController : ControllerBase
    {
        private readonly ExternalLinkService externalService;

        public ExternalLinkController(ExternalLinkService externalService)
        {
            this.externalService = externalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDriver(int driverNumber)
        {
            var driver = await externalService.GetDriver(driverNumber);
            return driver != null ? Ok(driver) : StatusCode(500, "Erro ao consultar Piloto...");
        }
    }
}