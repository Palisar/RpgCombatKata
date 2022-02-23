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
            CharacterCombatProxy heroProxy = new(melee);
            CharacterCombatProxy villanProxy = new(villanR);
            var attack = dice.Next(1, 7);

            engine.ApplyRules(heroProxy, villanProxy, attack);
            
            villanR.HitPoints.Should().Be(villanR.MaxHitPoints - attack);
        }

        [Fact]
        public void KillCharacter()
        {
            CharacterCombatProxy heroProxy = new(melee);
            CharacterCombatProxy villanProxy = new(villanR);

            engine.ApplyRules(heroProxy, villanProxy, 1001);

            villanR.IsAlive.Should().BeFalse();
        }

        [Fact]
        public void HealCharacter()
        {
            CharacterCombatProxy healerProxy = new(healer);
            CharacterCombatProxy meleeProxy = new(melee);

            healerProxy.JoinFaction(Factions.Plops);
            meleeProxy.JoinFaction(Factions.Plops);
            meleeProxy.TakeDamage(12);
            engine.ApplyRules(healerProxy, meleeProxy, 2);

            melee.HitPoints.Should().Be(990);
        }
        [Fact]
        public void LevelUp()
        {
            CharacterCombatProxy heroProxy = new(melee);

            heroProxy.LevelUp();
            heroProxy.LevelUp();

            melee.Level.Should().Be(3);
        }

        [Fact]
        public void AttackLowerLevel()
        {
            CharacterCombatProxy heroProxy = new(melee);
            CharacterCombatProxy villanProxy = new(villanR);

            for (int i = 0; i < 5; i++)
            {
                heroProxy.LevelUp();
            }

            engine.ApplyRules(heroProxy, villanProxy, 12);
            villanR.HitPoints.Should().Be(982);
        }

        [Fact]
        public void AttackHigherLevel()
        {
            CharacterCombatProxy heroProxy = new(melee);
            CharacterCombatProxy villanProxy = new(villanR);

            for (int i = 0; i < 5; i++)
            {
                villanProxy.LevelUp();
            }

            engine.ApplyRules(heroProxy, villanProxy, 12);
            villanR.HitPoints.Should().Be(994);
        }

        [Fact]
        public void AttackHigherLevelOddNumber()
        {
            CharacterCombatProxy heroProxy = new(melee);
            CharacterCombatProxy villanProxy = new(villanR);

            for (int i = 0; i < 5; i++)
            {
                villanProxy.LevelUp();
            }

            engine.ApplyRules(heroProxy, villanProxy, 13);
            villanR.HitPoints.Should().Be(994);
        }

        [Fact]
        public void CantAttackSelf()
        {
            CharacterCombatProxy heroProxy = new(melee);
            engine.ApplyRules(heroProxy, heroProxy, 100);
            melee.HitPoints.Should().Be(melee.MaxHitPoints);
        }

        [Fact]
        public void CanOnlyHealAlly()
        {
            CharacterCombatProxy heroProxy = new(melee);
            CharacterCombatProxy villanProxy = new(villanR);
            CharacterCombatProxy healerProxy = new CharacterCombatProxy(healer);

            heroProxy.JoinFaction(Factions.Plops);
            engine.ApplyRules(heroProxy, villanProxy, 13);
            engine.ApplyRules(healerProxy, villanProxy, 100);

            villanR.HitPoints.Should().Be(987);
        }

        [Fact]
        public void AttactAtRangeMelee()
        {
            CharacterCombatProxy heroProxy = new(melee);
            CharacterCombatProxy villanProxy = new(villanR);

            engine.ApplyRules(heroProxy, villanProxy, 12);

            villanR.HitPoints.Should().Be(988);
        }

        [Fact]
        public void CantReachMelee()
        {
            CharacterCombatProxy heroProxy = new(melee);
            CharacterCombatProxy villanProxy = new(villanR);
            heroProxy.SetPosition(0, 1);
            villanProxy.SetPosition(5, 6);

            engine.ApplyRules(heroProxy, villanProxy, 12);

            villanR.HitPoints.Should().Be(villanProxy.MaxHP);
        }

        [Fact]
        public void AttackAtLongRange()
        {

            CharacterCombatProxy heroProxy = new(ranged);
            CharacterCombatProxy villanProxy = new(villanR);
            heroProxy.SetPosition(0, 1);
            villanProxy.SetPosition(5, 6);

            engine.ApplyRules(heroProxy, villanProxy, 13);

            villanR.HitPoints.Should().Be(987);
        }

        [Fact]
        public void CantReachRange()
        {
            CharacterCombatProxy heroProxy = new(melee);
            CharacterCombatProxy villanProxy = new(villanR);
            heroProxy.SetPosition(0, 1);
            villanProxy.SetPosition(20, 6);

            engine.ApplyRules(heroProxy, villanProxy, 12);

            melee.HitPoints.Should().Be(melee.MaxHitPoints);
        }

        [Fact]
        public void CanHealAlly()
        {
            CharacterCombatProxy heroProxy = new(melee);
            CharacterCombatProxy sideKickProxy = new(healer);
            CharacterCombatProxy villanProxy = new(villanR);

            heroProxy.JoinFaction(Factions.Plops);
            sideKickProxy.JoinFaction(Factions.Plops);


            engine.ApplyRules(villanProxy, heroProxy, 12);

            engine.ApplyRules(sideKickProxy, heroProxy, 2);

            melee.HitPoints.Should().Be(990);
        }

        [Fact]
        public void CantHealEnemy()
        {
            CharacterCombatProxy heroProxy = new(melee);
            CharacterCombatProxy sideKickProxy = new(healer);
            CharacterCombatProxy villanProxy = new(villanR);

            heroProxy.JoinFaction(Factions.Plops);
            sideKickProxy.JoinFaction(Factions.Plops);
            villanProxy.JoinFaction(Factions.Warfarts);

            engine.ApplyRules(heroProxy, villanProxy, 10);

            engine.ApplyRules(sideKickProxy, villanProxy, 12);

            villanR.HitPoints.Should().Be(990);
        }

        [Fact]
        public void CantAttackAlly()
        {
            CharacterCombatProxy heroProxy = new(melee);
            CharacterCombatProxy sideKickProxy = new(ranged);
            
            heroProxy.JoinFaction(Factions.Plops);
            sideKickProxy.JoinFaction(Factions.Plops);

            engine.ApplyRules(heroProxy, sideKickProxy, 12);

            ranged.HitPoints.Should().Be(ranged.MaxHitPoints);
        }
    }
}
