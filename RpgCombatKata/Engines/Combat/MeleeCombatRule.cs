using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Engines.Combat
{
    public class MeleeCombatRule : BaseCombatRule
    {
        public MeleeCombatRule(CharacterProxy attacker, CharacterProxy target) : base(attacker, target)
        {
        }
        public override bool CanReach()
        {
            return base.attacker.Type == CombatType.Melee && IsInRangeCheck();
        }

        public override bool IsInRangeCheck()
        {
            //formula finds the distance between 2 points 
            var squareXs = Math.Abs(Math.Pow((base.attacker.Position.X - base.target.Position.X), 2));
            var squareYs = Math.Abs(Math.Pow((base.attacker.Position.Y - base.target.Position.Y), 2));
            return Math.Sqrt(squareYs + squareXs) <= 2;
        }
    }
}
