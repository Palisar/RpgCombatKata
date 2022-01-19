using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Interfaces
{
    public interface IFactionList
    {
        public HashSet<Factions> Factions { get; }
    }
}
