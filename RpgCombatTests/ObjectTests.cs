


namespace RpgTests
{
    public class ObjectTests
    {
        [Fact]
        public void CanTakeDamage()
        {
            var tree = new GameObject("tree", 100);
            var treeProxy = new ObjectProxy(tree);
            Character heroM = new("Hero", CombatType.Melee);
            var proxy = new CharacterProxy(heroM);
            var engine = new CombatRulesEngine.Builder()
                .WithMeleeCombatRule()
                .Build();

            engine.ApplyRules(proxy, treeProxy, 12);

            treeProxy.HP.Should().Be(88);

        }
    }
}
