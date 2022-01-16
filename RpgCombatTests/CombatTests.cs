using RpgCombatKata.Engines.Combat;
using System;

namespace RpgTests
{
    public class CombatTests
    {
        private readonly Random dice = new();
        private readonly Character heroM = new("Hero", CombatType.Melee);
        private readonly Character sideKickM = new("SideKick", CombatType.Melee);
        private readonly Character villanR = new("Villan", CombatType.Ranged);
        [Fact]
        public void Attack()
        {
            CharacterProxy heroProxy = new(heroM);
            CharacterProxy villanProxy = new(villanR);
            var attack = dice.Next(1, 7);

            heroProxy.Attack(villanProxy, attack, heroProxy);
            villanR.HP.Should().Be(villanR.MaxHP - attack);
        }

        [Fact]
        public void KillCharacter()
        {
            CharacterProxy heroProxy = new(heroM);
            CharacterProxy villanProxy = new(villanR);

            heroProxy.Attack(villanProxy, 1001, heroProxy);

            villanR.IsAlive.Should().BeFalse();
        }

        [Fact]
        public void HealCharacter()
        {
            CharacterProxy heroProxy = new(heroM);
            CharacterProxy villanProxy = new(villanR);

            heroProxy.Attack(villanProxy, 12, heroProxy);
            villanProxy.CastHeal(villanProxy, 6);

            villanR.HP.Should().Be(994);
        }
        [Fact]
        public void LevelUp()
        {
            CharacterProxy heroProxy = new(heroM);

            heroProxy.LevelUp();
            heroProxy.LevelUp();

            heroM.Level.Should().Be(3);
        }

        [Fact]
        public void AttackLowerLevel()
        {
            CharacterProxy heroProxy = new(heroM);
            CharacterProxy villanProxy = new(villanR);

            for (int i = 0; i < 5; i++)
            {
                heroProxy.LevelUp();
            }

            heroProxy.Attack(villanProxy, 12, heroProxy);
            villanR.HP.Should().Be(982);
        }

        [Fact]
        public void AttackHigherLevel()
        {
            CharacterProxy heroProxy = new(heroM);
            CharacterProxy villanProxy = new(villanR);

            for (int i = 0; i < 5; i++)
            {
                villanProxy.LevelUp();
            }

            heroProxy.Attack(villanProxy, 12, heroProxy);
            villanR.HP.Should().Be(994);
        }

        [Fact]
        public void AttackHigherLevelOddNumber()
        {
            CharacterProxy heroProxy = new(heroM);
            CharacterProxy villanProxy = new(villanR);

            for (int i = 0; i < 5; i++)
            {
                villanProxy.LevelUp();
            }

            heroProxy.Attack(villanProxy, 13, heroProxy);
            villanR.HP.Should().Be(994);
        }

        [Fact]
        public void CantAttackSelf()
        {
            CharacterProxy heroProxy = new(heroM);
            heroProxy.Attack(heroProxy, 13, heroProxy);

            heroM.HP.Should().Be(heroM.MaxHP);
        }

        [Fact]
        public void CanOnlyHealSelf()
        {
            CharacterProxy heroProxy = new(heroM);
            CharacterProxy villanProxy = new(villanR);
            heroProxy.Attack(villanProxy, 13, heroProxy);

            villanR.HP.Should().Be(987);
        }

        [Fact]
        public void AttactAtRangeMelee()
        {
            CharacterProxy heroProxy = new(heroM);
            CharacterProxy villanProxy = new(villanR);

            var combat = new MeleeCombatRule(heroProxy, villanProxy);

            combat.MakeAction(13);

            villanR.HP.Should().Be(987);
        }

        [Fact]
        public void CantReachMelee()
        {
            CharacterProxy heroProxy = new(heroM);
            CharacterProxy villanProxy = new(villanR);
            heroProxy.SetPosition(0, 1);
            villanProxy.SetPosition(5, 6);

            var combat = new MeleeCombatRule(heroProxy, villanProxy);

            combat.MakeAction(13);

            villanR.HP.Should().Be(villanProxy.MaxHP);
        }

        [Fact]
        public void AttackAtLongRange()
        {

            CharacterProxy heroProxy = new(heroM);
            CharacterProxy villanProxy = new(villanR);
            heroProxy.SetPosition(0, 1);
            villanProxy.SetPosition(5, 6);

            var combat = new RangedCombatRule(villanProxy, heroProxy);
            combat.MakeAction(13);

            heroM.HP.Should().Be(987);
        }

        [Fact]
        public void CantReachRange()
        {
            CharacterProxy heroProxy = new(heroM);
            CharacterProxy villanProxy = new(villanR);
            heroProxy.SetPosition(0, 1);
            villanProxy.SetPosition(20, 6);

            var combat = new RangedCombatRule(villanProxy, heroProxy);
            combat.MakeAction(13);

            heroM.HP.Should().Be(heroM.MaxHP);
        }

        [Fact]
        public void CanHealAlly()
        {
            CharacterProxy heroProxy = new(heroM);
            CharacterProxy sideKickProxy = new(sideKickM);
            CharacterProxy villanProxy = new(villanR);

            heroProxy.JoinFaction(Factions.Plops);
            sideKickProxy.JoinFaction(Factions.Plops);

            var combact = new RangedCombatRule(villanProxy, sideKickProxy);
            combact.MakeAction(10);

            var healing = new HealingRule(heroProxy, sideKickProxy);
            healing.MakeAction(2);

            sideKickM.HP.Should().Be(992);
        }

        [Fact]
        public void CantHealEnemy()
        {
            CharacterProxy heroProxy = new(heroM);
            CharacterProxy sideKickProxy = new(sideKickM);
            CharacterProxy villanProxy = new(villanR);

            heroProxy.JoinFaction(Factions.Plops);
            sideKickProxy.JoinFaction(Factions.Plops);
            villanProxy.JoinFaction(Factions.Warfarts);

            var combact = new MeleeCombatRule(heroProxy, villanProxy);
            combact.MakeAction(10);

            var healing = new HealingRule(heroProxy, villanProxy);
            healing.MakeAction(2);

            villanR.HP.Should().Be(990);
        }

        [Fact]
        public void CantAttackAlly()
        {
            CharacterProxy heroProxy = new(heroM);
            CharacterProxy sideKickProxy = new(sideKickM);
            
            heroProxy.JoinFaction(Factions.Plops);
            sideKickProxy.JoinFaction(Factions.Plops);

            var combact = new MeleeCombatRule(heroProxy, sideKickProxy);
            combact.MakeAction(10);

            sideKickM.HP.Should().Be(sideKickM.MaxHP);
        }
    }
}
