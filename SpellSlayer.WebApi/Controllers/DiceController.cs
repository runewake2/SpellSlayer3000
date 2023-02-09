using Microsoft.AspNetCore.Mvc;
using SpellSlayer.WebApi.Models;
using System.Text.RegularExpressions;

namespace SpellSlayer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiceController : ControllerBase
    {
        private static readonly Random random = new Random();
        private readonly ILogger<DiceController> _logger;

        public DiceController(ILogger<DiceController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "RollDice")]
        public ActionResult<DiceRoll> Post([FromQuery]string dice)
        {
            SpellDamage damage;
            try
            {
                damage = DiceParser.Parse(dice);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            List<int> diceResults = new();
            for(int i = 0; i < damage.DiceCount; ++i)
            {
                // Random selects between 0 (inclusive) and the max value (exclusive). Add 1 to behave like dice.
                diceResults.Add(random.Next(damage.DiceSize) + 1);
            }
            return Ok(new DiceRoll()
            {
                Total = diceResults.Sum(),
                DiceFaces = diceResults.ToArray()
            });
        }
    }
}