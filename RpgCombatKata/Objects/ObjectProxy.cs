using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata.Objects
{
    public class ObjectProxy : ICombatant
    {
        private readonly GameObject obj;

        public ObjectProxy(GameObject obj)
        {
            this.obj = obj;
        }
        
        public bool IsAlive => obj.IsAlive;

        public int MaxHP => obj.MaxHP;

        public int HP => obj.HP;

        public int Level => obj.Level;

        public Position Position => obj.Position;

        public CombatType Type => CombatType.None;

        HashSet<Factions> IFactionList.Factions => obj.Factions;
        public void RecieveHealing(int heal)
        {
            //cannot be healed
        }

        public void TakeDamage(int dmg)
        {
            obj.HP -= dmg;
            if (HP <= 0)
            {
                obj.HP = 0;
                obj.IsAlive = false;
            }
        }
    }
}
