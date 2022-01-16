using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgCombatKata
{
    public class CombatEncounter
    {
        private readonly IList<Character> _characters;
        private readonly Random dice = new();
        public CombatEncounter(IList<Character> characters)
        {
            _characters = characters;
        }

        //public void StartCombat()
        //{
        //    bool encounterOver = false;
        //    while (!encounterOver)
        //    {
        //        foreach (var character in _characters)
        //        {
        //            Console.WriteLine($"What will {character.Name} do?");
        //            Console.WriteLine(character.ToString());
        //            char key = Console.ReadKey(true).KeyChar;
        //            switch (char.ToLower(key))
        //            {
        //                case 'a':
        //                    //attack
        //                    break;
        //                case 'h':
        //                    //heal
        //                    break;
        //                default:
        //                    Console.WriteLine("Turn Skipped");
        //                    break;
        //            }
        //        }
        //    }
        //}
    }
}
