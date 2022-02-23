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
        public Character(string name, CombatType type)
        {
            this.Name = name;
            this.Type = type;
            MaxHitPoints = 1000;
            HitPoints = 1000;
            Level = 1;
            Factions = new HashSet<Factions>();
        }

        public string Name { get; init; }
        public int MaxHitPoints { get; set; }
        public int HitPoints { get; set; }
        public Position Position { get; set; }
        public int Level { get; set; }
        public bool IsAlive { get; set; } = true;
        public CombatType Type { get; set; }
        public int Inititive { get; set; }

        public HashSet<Factions> Factions { get; set; }

        public override string ToString()
        {
            return $@"{Name}
Level : {Level}
HP : {HitPoints}/{MaxHitPoints}
Type : {Type}";
        }
    }
}
