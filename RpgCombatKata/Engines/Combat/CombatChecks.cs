using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Engines.Combat
{
    public static class CombatChecks
    {
        /// <summary>
        /// Checks the range of two Combatants to see if an action will make it.
        /// </summary>
        /// <param name="target">The target of the spell</param>
        /// <param name="attacker">The action user.</param>
        /// <param name="range">The range of the ability.</param>
        /// <returns></returns>
        public static bool IsInRangeOf(this ICombatant target, ICombatant attacker, int range)
        {
            //formula finds the distance between 2 points 
            var squareXs = Math.Abs(Math.Pow((target.Position.X - attacker.Position.X), 2));
            var squareYs = Math.Abs(Math.Pow((target.Position.Y - attacker.Position.Y), 2));

            return Math.Sqrt(squareYs + squareXs) <= range;
        }

        public static bool IsAllyOf(this ICombatant attacker, ICombatant target)
        {
            return target.Factions.Intersect(attacker.Factions).Any();
        }
    }
}
