using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata
{
    public enum CombatType
    {
        Melee,
        Ranged
    }
    public class Character
    {
        public string Name { get; init; }
        public int MaxHP { get; set; } = 1000;
        public int HP { get; set; } = 1000;
        public int Level { get; set; } = 1;
        public bool IsAlive { get; set; } = true;
        public Position Position { get; set; } 
        public CombatType Type { get; set; }
        public int Inititive { get; set; }
        public Character(string name, CombatType type)
        {
            this.Name = name;
            this.Type = type;
        }

        public override string ToString()
        {
            return $@"{Name}
Level : {Level}
HP : {HP}/{MaxHP}
Type : {Type}";
        }
    }
}
