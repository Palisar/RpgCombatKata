using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Engines.Combat
{
    public abstract class BaseCombatRule : BaseRule
    {
        protected readonly CharacterProxy attacker;
        protected readonly CharacterProxy target;

        public BaseCombatRule(CharacterProxy attacker, CharacterProxy target)
        {
            this.attacker = attacker;
            this.target = target;
        }

        public override bool CanReach()
        {
            return false;
        }

        public override bool IsInRangeCheck()
        {
            return false;
        }

        public void MakeAttack(int dmg)
        {
            attacker.Attack(target, dmg, attacker);
        }
    }
}
