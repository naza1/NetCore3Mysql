using System.Threading.Tasks;
using BeachMdq.Api.Dtos;
using BeachMdq.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeachMdq.Api.Controllers
{
    [Route("[controller]")]
    public class SpaController : ControllerBase
    {
        private readonly ISpaService _spaService;

        public SpaController(ISpaService spaService)
        {
            _spaService = spaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int spaCode)
        {
            var result = await _spaService.GetSpa(spaCode);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SpaDto spaDto)
        {
            var result = await _spaService.AddSpa(spaDto.Name);

            if (!result.Success)
                return BadRequest(result.Errors);

            return Ok("Spa created correctly");
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<IActionResult> GetSpaByUser([FromQuery] int userId)
        {
            var result = await _spaService.GetSpaByUser(userId);

            if (result != null)
                return Ok(result);

            return NotFound();
        }
    }
}
