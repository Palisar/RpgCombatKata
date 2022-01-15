using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Engines.Combat
{
    public abstract class BaseRule
    {
        public abstract bool CanReach();
        public abstract bool IsInRangeCheck();
    }
}
