namespace SpellSlayer.WebApi.Models
{
    public class DiceRoll
    {
        public int Total { get; set; }
        public IEnumerable<int> DiceFaces { get; set; }
    }
}
