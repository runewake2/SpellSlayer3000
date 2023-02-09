using SpellSlayer.WebApi.Models;
using System.Text.RegularExpressions;

namespace SpellSlayer.WebApi
{
    public static class DiceParser
    {
        private const string regex = @"\d+d\d+"; // Matches "#d#" format

        public static SpellDamage Parse(string dice)
        {
            if (!Regex.IsMatch(dice, regex))
            {
                throw new DiceFormatException();
            }
            var splitPool = dice.Split("d");
            if (splitPool.Length != 2)
            {
                throw new DiceFormatException();
            }
            var (count, dimension) = (int.Parse(splitPool[0]), int.Parse(splitPool[1]));
            return new()
            {
                DiceCount = count,
                DiceSize = dimension,
                Modifier = 0
            };
        }
    }

    public class DiceFormatException : Exception
    {
        public DiceFormatException() : base("Dice pool was incorrectly formatted. Expects: #d#, ex 3d10")
        {
        }
    }
}
