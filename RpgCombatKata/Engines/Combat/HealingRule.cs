using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Engines.Combat
{
    public class HealingRule : BaseRule
    {
        public override void MakeAction(ICombatant healer, ICombatant target, int amount)
        {
            if (!healer.IsAllyOf(target))
            {
                Console.WriteLine("You can only heal your allies!");
            }
            else if (!target.IsInRangeOf(healer, 30))
            {
                Console.WriteLine("Target must be in range!");
            }
            else
            {
                healer.CastHeal(target, amount);
            }
        }

        public override bool IsMatch(ICombatant healer)
        {
            return healer.Type == CombatType.Healer;
        }
    }
}
