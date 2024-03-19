using Colors;

namespace Cards.Factories;

public class SpellFactory : ACardFactory<Spell>
{
    public override Spell CreateCard(AColor color)
    {
        return new() { Color = color, Cost = 0 };
    }

    public Spell CreateCard(AColor color, int cost, Effect[] effects)
    {
        return new()
        {
            Color = color,
            Cost = cost,
            Effects = effects.ToList()
        };
    }

    public Spell CreateInstantCard(AColor color, int cost, Effect[] effects)
    {
        return new()
        {
            Color = color,
            Cost = cost,
            Effects = effects.ToList(),
            IsInstantaneous = true
        };
    }
}
