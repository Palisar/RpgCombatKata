using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Interfaces
{
    public interface IHealthBar
    {
        public int MaxHP { get; set; }
        public int HP { get; set; }
    }
}
