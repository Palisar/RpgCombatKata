using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata
{
    public class Character
    {
        public Character(string name)
        {
            Name = name;
        }
        public string Name { get; init; }
        public int MaxHP { get; set; } = 1000;
        public int Health { get; set; } = 1000;
        public int Level { get; set; } = 1;
        public bool IsAlive { get; set; } = true;

        public override string ToString()
        {
            return $@"{Name}
Level : {Level}
HP : {Health}/{MaxHP}";
        }
    }
}
