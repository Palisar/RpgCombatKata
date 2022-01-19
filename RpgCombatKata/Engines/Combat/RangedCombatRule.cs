using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Engines.Combat
{
    public class RangedCombatRule : BaseRule
    {
        public override void MakeAction(ICombatant attacker, ICombatant target, int amount)
        {
            if (attacker.IsAllyOf(target))
            {
                Console.WriteLine("You cannot attack your allies!");
            }
            else if (!target.IsInRangeOf(attacker, 20))
            {
                Console.WriteLine("Target must be in range!");
            }
            else if (attacker == target)
            {
                Console.WriteLine("Cannot attack self!");
            }
            else
            {
                attacker.MakeAttack(target, amount);
            }
        }

        public override bool IsMatch(ICombatant attacker)
        {
            return attacker.Type == CombatType.Ranged;
        }
    }
}
