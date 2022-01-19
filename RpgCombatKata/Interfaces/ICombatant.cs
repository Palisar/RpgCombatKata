using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Interfaces
{
    public interface ICombatant : ITakeDamage, IFactionList, IHealthBar, ILevel, ICanBeHealed
    {
        public Position Position { get; }
        public CombatType Type { get; }
    }
}
