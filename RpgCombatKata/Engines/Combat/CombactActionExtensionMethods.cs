using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Engines.Combat
{
    public static class CombactActionExtensionMethods
    {
        public static void MakeAttack(this ICombatant attacker, ICombatant target, int dmg)
        {
            if (target.Level - 5 >= attacker.Level)
            {
                target.TakeDamage(dmg / 2);
            }
            else if (target.Level + 5 <= attacker.Level)
            {
                target.TakeDamage(dmg + (dmg / 2));
            }
            else
            {
                target.TakeDamage(dmg);
            }
        }

        public static void CastHeal(this ICombatant caster, ICombatant target, int amount)
        {
            target.RecieveHealing(amount);
        }
    }
}
