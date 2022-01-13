namespace RpgCombatTests
{
    public class CharacterTests
    {
        [Fact]
        public void CreateCharacter()
        {
            var character = new Character("Cloud");
            var proxy = new CharacterProxy(character);
            proxy.Name.Should().Be(character.Name);
            proxy.Health.Should().Be(character.Health);
            proxy.Level.Should().Be(character.Level);
            proxy.IsAlive.Should().Be(character.IsAlive);
            proxy.MaxHP.Should().Be(character.MaxHP);
        }
    }
}