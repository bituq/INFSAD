namespace Cards.Factories;

public class CreatureFactory : APermanentFactory<Creature>
{
    public CreatureFactory(Player owner)
        : base(owner) { }

    public override Creature CreateCard(Color color)
    {
        return new() { Color = color, Owner = owner };
    }

    public Creature CreateCard(Color color, int attack, int defence)
    {
        return new()
        {
            Color = color,
            Owner = owner,
            Attack = attack,
            Defence = defence
        };
    }
}
