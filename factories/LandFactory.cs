using Cards.States;

namespace Cards.Factories;

public class LandFactory : APermanentFactory
{
    public LandFactory(Player owner)
        : base(owner) { }

    public override Land CreateCard(Color color)
    {
        return new()
        {
            Color = color,
            Owner = owner,
        };
    }
}
