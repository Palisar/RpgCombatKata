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
        public int MaxHP => _character.MaxHP;
        public int Health => _character.Health;
        public int Level => _character.Level;
        public bool IsAlive => _character.IsAlive;

        public void TakeDamage(int dmg)
        {
            if ((Health - dmg) < 0)
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
        public int CastHeal(CharacterProxy character, int heal)
        {
            if (character.IsAlive)
                return heal;
            else 
                return 0;
        }
        public void RecieveHealing(CharacterProxy character, int heal)
        {
            if (character.Health + heal < character.MaxHP)
            {
                _character.Health = character.MaxHP;
            }
            else
            {
                _character.Health += heal;
            }
        }
    }
}
}
