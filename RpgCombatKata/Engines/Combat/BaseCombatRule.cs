using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Engines.Combat
{
    public abstract class BaseCombatRule
    {
        protected readonly CharacterProxy attacker;
        protected readonly CharacterProxy target;

        public BaseCombatRule(CharacterProxy attacker, CharacterProxy target)
        {
            this.attacker = attacker;
            this.target = target;
        }
        public abstract bool IsInRange();

        public abstract void MakeAction(int amount);

        public bool IsAlly()
        {
            return attacker.Factions.Intersect(target.Factions).Any();
        }
    }
}
