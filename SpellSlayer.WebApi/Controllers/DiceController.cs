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
        private const string regex = @"\d+d\d+"; // Matches "#d#" format
        private readonly ILogger<DiceController> _logger;

        public DiceController(ILogger<DiceController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "RollDice")]
        public ActionResult<DiceRoll> Post([FromQuery]string dice)
        {
            if (!Regex.IsMatch(dice, regex))
            {
                return BadRequest("Dice pool was incorrectly formatted. Expects: #d#, ex 3d10");
            }
            var splitPool = dice.Split("d");
            if (splitPool.Length != 2 ) {
                return BadRequest("Dice pool was incorrectly formatted. Expects: #d#, ex 3d10");
            }
            var (count, dimension) = (int.Parse(splitPool[0]), int.Parse(splitPool[1]));
            List<int> diceResults = new();
            for(int i = 0; i < count; ++i)
            {
                // Random selects between 0 (inclusive) and the max value (exclusive). Add 1 to behave like dice.
                diceResults.Add(random.Next(dimension) + 1);
            }
            return Ok(new DiceRoll()
            {
                Total = diceResults.Sum(),
                DiceFaces = diceResults.ToArray()
            });
        }
    }
}