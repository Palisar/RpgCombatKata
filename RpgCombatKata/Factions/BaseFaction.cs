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
        Plops,
        None
    }
    public abstract class BaseFaction
    {
        public Factions Type { get; set; }
        public string Name
        {
            get
            {
                return Type.ToString();
            }
        }
        public List<Character>? Members { get; set; }

        public abstract void AddMembers();
        public abstract void RemoveMembers();
    }
}
