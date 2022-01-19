using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Engines.Combat
{
    public class CombatRulesEngine
    {
        private List<BaseRule> _rules = new();
        private CombatRulesEngine(List<BaseRule> rules)
        {
            _rules = rules;
        }

        public void ApplyRules(ICombatant user, ICombatant target, int amount)
        {
            foreach (var rule in _rules)
            {

                if (rule.IsMatch(user))
                {
                    rule.MakeAction(user, target, amount);
                }
            }
        }
       
        public class Builder
        {
            private List<BaseRule> _builderRules = new();

            public Builder WithHealingRule()
            {
                _builderRules.Add(new HealingRule());
                return this;
            }
            public Builder WithMeleeCombatRule()
            {
                _builderRules.Add(new MeleeCombatRule());
                return this;
            }
            public Builder WithRangedCombatRule()
            {
                _builderRules.Add(new RangedCombatRule());
                return this;
            }
            public CombatRulesEngine Build()
            {
                return new CombatRulesEngine(_builderRules);
            }

        }
    }
}
