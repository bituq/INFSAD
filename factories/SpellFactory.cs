using Colors;

namespace Cards.Factories;

public class SpellFactory : ACardFactory<Spell>
{
    public override Spell CreateCard(AColor color)
    {
        return new() { Color = color, Cost = 0 };
    }

    public Spell CreateCard(AColor color, int cost, Effect effect)
    {
        return new()
        {
            Color = color,
            Cost = cost,
            Effect = effect
        };
    }

    public Spell CreateInstantCard(AColor color, int cost, Effect effect)
    {
        return new()
        {
            Color = color,
            Cost = cost,
            Effect = effect,
            IsInstantaneous = true
        };
    }

    public Spell CreateContinuousCard(AColor color, int cost, Effect effect)
    {
        return new()
        {
            Color = color,
            Cost = cost,
            Effect = effect,
            IsContinuous = true
        };
    }
}