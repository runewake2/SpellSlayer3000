using Microsoft.AspNetCore.Mvc;
using SpellSlayer.WebApi.Models;

namespace SpellSlayer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpellController : ControllerBase
    {
        private readonly ILogger<SpellController> _logger;

        public SpellController(ILogger<SpellController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSpell")]
        public IActionResult Get()
        {
            return Ok(new Spell() { Name = "Fireball" });
        }
    }
}