namespace SpellSlayer.WebApi.Models
{

    public class DndSpellObject
    {
        public string index { get; set; }
        public string name { get; set; }
        public string[] desc { get; set; }
        public string[] higher_level { get; set; }
        public string range { get; set; }
        public string[] components { get; set; }
        public string material { get; set; }
        public bool ritual { get; set; }
        public string duration { get; set; }
        public bool concentration { get; set; }
        public string casting_time { get; set; }
        public int level { get; set; }
        public Damage damage { get; set; }
        public Dc dc { get; set; }
        public Area_Of_Effect area_of_effect { get; set; }
        public School school { get; set; }
        public Class1[] classes { get; set; }
        public Subclass[] subclasses { get; set; }
        public string url { get; set; }
    }

    public class Damage
    {
        public Damage_Type damage_type { get; set; }
        public Dictionary<int, string> damage_at_slot_level { get; set; }
    }

    public class Damage_Type
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Dc
    {
        public Dc_Type dc_type { get; set; }
        public string dc_success { get; set; }
    }

    public class Dc_Type
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Area_Of_Effect
    {
        public string type { get; set; }
        public int size { get; set; }
    }

    public class School
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Class1
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Subclass
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

}
