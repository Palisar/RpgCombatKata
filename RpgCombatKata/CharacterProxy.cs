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
        public int HP => _character.HP;
        public int Level => _character.Level;
        public bool IsAlive => _character.IsAlive;
        public Position Position => _character.Position; // in meters
        public CombatType Type => _character.Type;
        public int Initive => _character.Inititive;

        public HashSet<Factions> Factions => _character.Factions;
        
        //General Methods for anywhere use.
        #region General
        public void LevelUp()
        {
            _character.Level++;
        }
        #endregion

        //Methods are the acitons a character can take in combat.
        #region Combat
        public void Attack(CharacterProxy target, int dmg, CharacterProxy attacker)
        {
            if (target.IsAlive && target != attacker)
            {
                if (target.Level - 5 >= attacker.Level)
                {
                    target.TakeDamage(dmg / 2);
                }
                else if (target.Level + 5 <= attacker.Level)
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
            if (HP - dmg < 0)
            {
                _character.HP = 0;
                Faint();
            }
            else
            {
                _character.HP -= Math.Abs(dmg);
            }
        }

        public void Faint()
        {
            Console.WriteLine($"{this.Name} has fainted!" );
            _character.IsAlive = false;
        }

        public void CastHeal(CharacterProxy target, int heal)
        {
            target.RecieveHealing(heal);
        }

        public void RecieveHealing(int heal)
        {
            if (_character.HP + heal > _character.MaxHP)
            {
                _character.HP = _character.MaxHP;
            }
            else
            {
                _character.HP += Math.Abs(heal);
            }
        }
        public void RollInititive(int diceRoll)
        {
            _character.Inititive = diceRoll;
        }

        public void SetPosition(int x, int y)
        {
            _character.Position = new Position(x, y);
        }
        #endregion Combat 

        //Methods Connected to factions.
        #region Faction
        public void JoinFaction(Factions faction)
        {
            _character.Factions.Add(faction);
        }
        public void LeaveFaciton(Factions faction)
        {
            _character.Factions.Remove(faction);
        }
        #endregion
    }
}
