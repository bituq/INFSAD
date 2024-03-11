using Cards.States;

namespace Cards.Factories;

public class LandFactory : APermanentFactory
{

    public override Land CreateCard(Color color)
    {
        return new()
        {
            Color = color
        };
    }
}
