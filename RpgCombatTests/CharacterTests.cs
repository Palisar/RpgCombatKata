namespace RpgCombatTests
{
    public class CharacterTests
    {
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

    }
}