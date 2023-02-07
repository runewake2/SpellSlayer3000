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

        [HttpGet("{spellName}/{level}")]
        public ActionResult<Spell> Get([FromRoute] string spellName, [FromRoute] int level)
        {
            return new Spell() { Name = spellName, Description = $"{level}" };
        }
    }
}