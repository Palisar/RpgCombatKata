using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Interfaces
{
    public interface ITakeDamage
    {
        public int MaxHP { get;}
        public int HP { get;}
        bool IsAlive { get; }

        public void TakeDamage(int dmg);
    }
}
