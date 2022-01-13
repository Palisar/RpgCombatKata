using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata
{
    public class CombatEncounter
    {
        private readonly IList<Character> _characters;
        public CombatEncounter(IList<Character> characters)
        {
            _characters = characters;
        }

    }
}
