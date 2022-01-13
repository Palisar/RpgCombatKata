using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTests
{
    public class CombatTests
    {
        private Random dice = new Random();
        private Character hero = new Character("Hero");
        private Character villan = new Character("Villan");
        [Fact]
        public void Attack()
        {
            CharacterProxy heroProxy = new CharacterProxy(hero);
            CharacterProxy villanProxy = new CharacterProxy(villan);
            var attack = dice.Next(1, 7);

            heroProxy.Attack(villanProxy, attack);
            villan.Health.Should().Be(villan.MaxHP - attack);
        }

        [Fact]
        public void KillCharacter()
        {
            CharacterProxy heroProxy = new CharacterProxy(hero);
            CharacterProxy villanProxy = new CharacterProxy(villan);
            
            heroProxy.Attack(villanProxy, 1001);

            villan.IsAlive.Should().BeFalse();
        }

        [Fact]
        public void HealCharacter()
        {
            CharacterProxy heroProxy = new CharacterProxy(hero);
            CharacterProxy villanProxy = new CharacterProxy(villan);
            
            heroProxy.Attack(villanProxy, 12);
            villanProxy.CastHeal(villanProxy, 6);

            villan.Health.Should().Be(994);
        }
        [Fact]
        public void LevelUp()
        {
            CharacterProxy heroProxy = new CharacterProxy(hero);
            heroProxy.LevelUp();
            heroProxy.LevelUp();
            hero.Level.Should().Be(3);
        }

        [Fact]
        public void AttackLowerLevel()
        {
            CharacterProxy heroProxy = new CharacterProxy(hero);
            CharacterProxy villanProxy = new CharacterProxy(villan);

            for (int i = 0; i < 5; i++)
            {
                heroProxy.LevelUp();
            }

            heroProxy.Attack(villanProxy, 12);
            villan.Health.Should().Be(982);
        }

        [Fact]
        public void AttackHigherLevel()
        {
            CharacterProxy heroProxy = new CharacterProxy(hero);
            CharacterProxy villanProxy = new CharacterProxy(villan);

            for (int i = 0; i < 5; i++)
            {
                villanProxy.LevelUp();
            }

            heroProxy.Attack(villanProxy, 12);
            villan.Health.Should().Be(994);
        }

        [Fact]
        public void AttackHigherLevelOddNumber()
        {
            CharacterProxy heroProxy = new CharacterProxy(hero);
            CharacterProxy villanProxy = new CharacterProxy(villan);

            for (int i = 0; i < 5; i++)
            {
                villanProxy.LevelUp();
            }

            heroProxy.Attack(villanProxy, 13);
            villan.Health.Should().Be(994);
        }

        [Fact]
        public void CantAttackSelf()
        {
            CharacterProxy heroProxy = new CharacterProxy(hero);
            heroProxy.Attack(heroProxy, 13);

            hero.Health.Should().Be(hero.MaxHP);
        }

        [Fact]
        public void CanOnlyHealSelf()
        {
            CharacterProxy heroProxy = new CharacterProxy(hero);
            CharacterProxy villanProxy = new CharacterProxy(villan);
            heroProxy.Attack(villanProxy, 13);
            
            villan.Health.Should().Be(987);
        }
    }
}
