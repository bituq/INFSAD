namespace Cards.Factories;

public class LandFactory : APermanentFactory<Land>
{
    public LandFactory(Player owner)
        : base(owner) { }

    public override Land CreateCard(Color color)
    {
        return new() { Color = color, Owner = owner };
    }
}
