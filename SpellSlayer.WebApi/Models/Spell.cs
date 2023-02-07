namespace SpellSlayer.WebApi.Models
{
    public class Spell
    {
        public string Name { get; set; }
        public SpellDamage Damage { get; set; }
        public string Description { get; set; }
    }
}
