using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata
{
    public enum Factions
    {
        Warfarts,
        Pizzers
    }
    public abstract class BaseFaction
    {
        public Factions Type { get; set; }
        public string? Name { get; set; }
        public List<Character>? Members { get; set; }

        public abstract void AddMembers();
        public abstract void RemoveMembers();
    }
}
