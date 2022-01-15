﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Engines.Combat
{
    public class RangedCombatRule : BaseCombatRule
    {
        public RangedCombatRule(CharacterProxy attacker, CharacterProxy target) : base(attacker, target)
        {
        }

        public override bool IsInRange()
        {
            //formula finds the distance between 2 points 
            var squareXs = Math.Abs(Math.Pow((base.attacker.Position.X - base.target.Position.X), 2));
            var squareYs = Math.Abs(Math.Pow((base.attacker.Position.Y - base.target.Position.Y), 2));

            return Math.Sqrt(squareYs + squareXs) <= 20
                && base.attacker.Type == CombatType.Ranged;
        }

        public override void MakeAction(int amount)
        {
            if (!IsAlly() && IsInRange())
            {
                attacker.Attack(target, amount, attacker);
            }
        }
    }
}
