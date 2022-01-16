using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata
{
    public class GameObject : ITakeDamage, IHealthBar
    {
        public GameObject(string name, int maxHP)
        {
            Name = name;
            MaxHP = maxHP;
            HP = maxHP;
        }
        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int HP { get; set; }
        public bool IsAlive { get; set; } = true;
        public void TakeDamage(int dmg)
        {
            HP -= dmg;
            if (HP <= 0)
            {
                IsAlive = false;
            }
        }
    }
}
