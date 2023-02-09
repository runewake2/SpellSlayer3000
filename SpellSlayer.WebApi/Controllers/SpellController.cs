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
        public async Task<ActionResult<Spell>> Get([FromRoute] string spellName, [FromRoute] int level)
        {
            HttpClient client = new()
            {
                BaseAddress = new Uri("https://www.dnd5eapi.co/api/"),
            };
            var result = await client.GetAsync($"spells/{spellName}");
            var parsed = await result.Content.ReadFromJsonAsync<DndSpellObject>();
            var damage = DiceParser.Parse(parsed?.damage.damage_at_slot_level[level] ?? "");
            return new Spell() { Name = spellName, Description = parsed.desc[0], Damage = damage };
        }
    }
}