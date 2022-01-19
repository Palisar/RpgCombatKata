

namespace RpgTests
{
    public class CombatTests
    {
        private readonly Random dice = new();
        private readonly Character melee = new("Hero", CombatType.Melee);
        private readonly Character ranged = new("SideKick", CombatType.Ranged);
        private readonly Character healer = new("Healer", CombatType.Healer);
        private readonly Character villanR = new("Villan", CombatType.Ranged);

        private readonly CombatRulesEngine engine ;
        public CombatTests()
        {
            engine = new CombatRulesEngine.Builder()
                .WithHealingRule()
                .WithMeleeCombatRule()
                .WithRangedCombatRule()
                .Build();
        }
        [Fact]
        public void Attack()
        {
            CharacterProxy heroProxy = new(melee);
            CharacterProxy villanProxy = new(villanR);
            var attack = dice.Next(1, 7);

            engine.ApplyRules(heroProxy, villanProxy, attack);
            
            villanR.HP.Should().Be(villanR.MaxHP - attack);
        }

        [Fact]
        public void KillCharacter()
        {
            CharacterProxy heroProxy = new(melee);
            CharacterProxy villanProxy = new(villanR);

            engine.ApplyRules(heroProxy, villanProxy, 1001);

            villanR.IsAlive.Should().BeFalse();
        }

        [Fact]
        public void HealCharacter()
        {
            CharacterProxy healerProxy = new(healer);
            CharacterProxy meleeProxy = new(melee);

            healerProxy.JoinFaction(Factions.Plops);
            meleeProxy.JoinFaction(Factions.Plops);
            meleeProxy.TakeDamage(12);
            engine.ApplyRules(healerProxy, meleeProxy, 2);

            melee.HP.Should().Be(990);
        }
        [Fact]
        public void LevelUp()
        {
            CharacterProxy heroProxy = new(melee);

            heroProxy.LevelUp();
            heroProxy.LevelUp();

            melee.Level.Should().Be(3);
        }

        [Fact]
        public void AttackLowerLevel()
        {
            CharacterProxy heroProxy = new(melee);
            CharacterProxy villanProxy = new(villanR);

            for (int i = 0; i < 5; i++)
            {
                heroProxy.LevelUp();
            }

            engine.ApplyRules(heroProxy, villanProxy, 12);
            villanR.HP.Should().Be(982);
        }

        [Fact]
        public void AttackHigherLevel()
        {
            CharacterProxy heroProxy = new(melee);
            CharacterProxy villanProxy = new(villanR);

            for (int i = 0; i < 5; i++)
            {
                villanProxy.LevelUp();
            }

            engine.ApplyRules(heroProxy, villanProxy, 12);
            villanR.HP.Should().Be(994);
        }

        [Fact]
        public void AttackHigherLevelOddNumber()
        {
            CharacterProxy heroProxy = new(melee);
            CharacterProxy villanProxy = new(villanR);

            for (int i = 0; i < 5; i++)
            {
                villanProxy.LevelUp();
            }

            engine.ApplyRules(heroProxy, villanProxy, 13);
            villanR.HP.Should().Be(994);
        }

        [Fact]
        public void CantAttackSelf()
        {
            CharacterProxy heroProxy = new(melee);
            engine.ApplyRules(heroProxy, heroProxy, 100);
            melee.HP.Should().Be(melee.MaxHP);
        }

        [Fact]
        public void CanOnlyHealAlly()
        {
            CharacterProxy heroProxy = new(melee);
            CharacterProxy villanProxy = new(villanR);
            CharacterProxy healerProxy = new CharacterProxy(healer);

            heroProxy.JoinFaction(Factions.Plops);
            engine.ApplyRules(heroProxy, villanProxy, 13);
            engine.ApplyRules(healerProxy, villanProxy, 100);

            villanR.HP.Should().Be(987);
        }

        [Fact]
        public void AttactAtRangeMelee()
        {
            CharacterProxy heroProxy = new(melee);
            CharacterProxy villanProxy = new(villanR);

            engine.ApplyRules(heroProxy, villanProxy, 12);

            villanR.HP.Should().Be(988);
        }

        [Fact]
        public void CantReachMelee()
        {
            CharacterProxy heroProxy = new(melee);
            CharacterProxy villanProxy = new(villanR);
            heroProxy.SetPosition(0, 1);
            villanProxy.SetPosition(5, 6);

            engine.ApplyRules(heroProxy, villanProxy, 12);

            villanR.HP.Should().Be(villanProxy.MaxHP);
        }

        [Fact]
        public void AttackAtLongRange()
        {

            CharacterProxy heroProxy = new(ranged);
            CharacterProxy villanProxy = new(villanR);
            heroProxy.SetPosition(0, 1);
            villanProxy.SetPosition(5, 6);

            engine.ApplyRules(heroProxy, villanProxy, 13);

            villanR.HP.Should().Be(987);
        }

        [Fact]
        public void CantReachRange()
        {
            CharacterProxy heroProxy = new(melee);
            CharacterProxy villanProxy = new(villanR);
            heroProxy.SetPosition(0, 1);
            villanProxy.SetPosition(20, 6);

            engine.ApplyRules(heroProxy, villanProxy, 12);

            melee.HP.Should().Be(melee.MaxHP);
        }

        [Fact]
        public void CanHealAlly()
        {
            CharacterProxy heroProxy = new(melee);
            CharacterProxy sideKickProxy = new(healer);
            CharacterProxy villanProxy = new(villanR);

            heroProxy.JoinFaction(Factions.Plops);
            sideKickProxy.JoinFaction(Factions.Plops);


            engine.ApplyRules(villanProxy, heroProxy, 12);

            engine.ApplyRules(sideKickProxy, heroProxy, 2);

            melee.HP.Should().Be(990);
        }

        [Fact]
        public void CantHealEnemy()
        {
            CharacterProxy heroProxy = new(melee);
            CharacterProxy sideKickProxy = new(healer);
            CharacterProxy villanProxy = new(villanR);

            heroProxy.JoinFaction(Factions.Plops);
            sideKickProxy.JoinFaction(Factions.Plops);
            villanProxy.JoinFaction(Factions.Warfarts);

            engine.ApplyRules(heroProxy, villanProxy, 10);

            engine.ApplyRules(sideKickProxy, villanProxy, 12);

            villanR.HP.Should().Be(990);
        }

        [Fact]
        public void CantAttackAlly()
        {
            CharacterProxy heroProxy = new(melee);
            CharacterProxy sideKickProxy = new(ranged);
            
            heroProxy.JoinFaction(Factions.Plops);
            sideKickProxy.JoinFaction(Factions.Plops);

            engine.ApplyRules(heroProxy, sideKickProxy, 12);

            ranged.HP.Should().Be(ranged.MaxHP);
        }
    }
}
