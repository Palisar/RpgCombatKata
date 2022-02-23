namespace RpgCombatKata
{
    public class CharacterCombatProxy : ICombatant
    {
        private readonly Character _character;

        public CharacterCombatProxy(Character character)
        {
            this._character = character;
        }
        public string Name => _character.Name;
        public int MaxHP => _character.MaxHitPoints;
        public int HP => _character.HitPoints;
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

        public void TakeDamage(int dmg)
        {
            if (HP - dmg < 0)
            {
                _character.HitPoints = 0;
                Faint();
            }
            else
            {
                _character.HitPoints -= Math.Abs(dmg);
            }
        }

        public void Faint()
        {
            Console.WriteLine($"{this.Name} has fainted!");
            _character.IsAlive = false;
        }

        

        public void RecieveHealing(int heal)
        {
            if (_character.HitPoints + heal > _character.MaxHitPoints)
            {
                _character.HitPoints = _character.MaxHitPoints;
            }
            else
            {
                _character.HitPoints += Math.Abs(heal);
            }
        }
        public void RollInititive(int modifier)
        {
            Random dice = new();
            _character.Inititive = dice.Next(1,20) + modifier;
        }

        public void SetPosition(int x, int y)
        {
            _character.Position = new Position(x, y);
        }

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
