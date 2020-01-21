using System.Linq;
using System.Threading.Tasks;
using BeachMdq.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BeachMdq.Api.Controllers
{
    [Route("[controller]")]
    public class FlagController : ControllerBase
    {
        private readonly ILogger<FlagController> _logger;
        private readonly IFlagService _flagService;

        public FlagController(
            ILogger<FlagController> logger, IFlagService flagService)
        {
            _logger = logger;
            _flagService = flagService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _flagService.GetFlags();

            if (result.Any())
                return Ok(result);

            return NotFound();
        }
    }
}