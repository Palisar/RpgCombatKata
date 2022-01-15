namespace RpgCombatTests
{
    public class CharacterTests
    {
        private readonly Character heroM = new("Hero", CombatType.Melee);
        private readonly Character sideKickM = new("SideKick", CombatType.Melee);
        private readonly Character villanR = new("Villan", CombatType.Ranged);

        [Fact]
        public void CreateCharacter()
        {
            var character = new Character("Cloud", CombatType.Melee);
            var proxy = new CharacterProxy(character);
            proxy.Name.Should().Be(character.Name);
            proxy.HP.Should().Be(character.HP);
            proxy.Level.Should().Be(character.Level);
            proxy.IsAlive.Should().Be(character.IsAlive);
            proxy.MaxHP.Should().Be(character.MaxHP);
        }

        [Fact]
        public void CanJoinFaction()
        {
            CharacterProxy heroProxy = new(heroM);
            heroProxy.JoinFaction(Factions.Plops);

            heroProxy.Factions.Should().HaveCount(1);
            heroProxy.Factions.Should().Contain(Factions.Plops);
        }

        [Fact]
        public void CanLeaveFaction()
        {
            CharacterProxy heroProxy = new(heroM);
            heroProxy.JoinFaction(Factions.Plops);
            heroProxy.LeaveFaciton(Factions.Plops);

            heroProxy.Factions.Should().HaveCount(0);
        }
    }
}