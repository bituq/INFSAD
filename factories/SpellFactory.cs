using Colors;

namespace Cards.Factories;

public class SpellFactory : ACardFactory<Spell>
{
    public override Spell CreateCard(Color color)
    {
        return new() { Color = color, Cost = 0 };
    }

    public Spell CreateCard(Color color, int cost, Effect[] effects)
    {
        return new()
        {
            Color = color,
            Cost = cost,
            Effects = effects.ToList()
        };
    }

    public Spell CreateInstantCard(Color color, int cost, Effect[] effects)
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
