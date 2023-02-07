namespace SpellSlayer.WebApi.Models
{
    public class SpellDamage
    {
        public int DiceCount { get; set; }
        public int DiceSize { get; set; }
        public int? Modifier { get; set; }
    }
}
