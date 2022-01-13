using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata
{
    public class CharacterProxy
    {
        private readonly Character _character;

        public CharacterProxy(Character character)
        {
            this._character = character;
        }
        public string Name => _character.Name;
        public int MaxHP => _character.MaxHP;
        public int Health => _character.Health;
        public int Level => _character.Level;
        public bool IsAlive => _character.IsAlive;

        public void Attack(CharacterProxy target, int dmg)
        {
            if (target.IsAlive && target != this)
            {
                if (target.Level - 5 >= this.Level)
                {
                    target.TakeDamage(dmg / 2);
                }
                else if (target.Level + 5 <= this.Level)
                {
                    target.TakeDamage(dmg + (dmg / 2));
                }
                else
                {
                    target.TakeDamage(dmg);
                }
            }
        }

        public void TakeDamage(int dmg)
        {
            if (Health - dmg < 0)
            {
                _character.Health = 0;
                Faint();
            }
            else
            {
                _character.Health -= dmg;
            }
        }

        public void Faint()
        {
            _character.IsAlive = false;
        }

        public void CastHeal(CharacterProxy target, int heal)
        {
            if (target.IsAlive && target == this)
                target.RecieveHealing(heal);
        }

        public void RecieveHealing(int heal)
        {
            if (_character.Health + heal > _character.MaxHP)
            {
                _character.Health = _character.MaxHP;
            }
            else
            {
                _character.Health += heal;
            }
        }

        public void LevelUp()
        {
            _character.Level++;
        }
    }
}
