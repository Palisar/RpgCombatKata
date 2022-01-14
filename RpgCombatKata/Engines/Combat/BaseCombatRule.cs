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
        public abstract bool CanReach();
        public void MakeAttack(int dmg)
        {
            attacker.Attack(target, dmg, attacker);
        }
        public abstract bool IsInRangeCheck();
    }
}
