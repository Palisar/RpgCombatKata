namespace RpgCombatKata
{
    public enum CombatType
    {
        None,
        Melee,
        Ranged,
        Healer,
    }
    public class Character
    {
        public string Name { get; init; }
        public int MaxHP { get; set; } = 1000;
        public int HP { get; set; } = 1000;
        public Position Position { get; set; }
        public int Level { get; set; } = 1;
        public bool IsAlive { get; set; } = true;
        public CombatType Type { get; set; }
        public int Inititive { get; set; }
        public Character(string name, CombatType type)
        {
            this.Name = name;
            this.Type = type;
        }
        public HashSet<Factions> Factions { get; set; } = new HashSet<Factions>();

        public override string ToString()
        {
            return $@"{Name}
Level : {Level}
HP : {HP}/{MaxHP}
Type : {Type}";
        }
    }
}
