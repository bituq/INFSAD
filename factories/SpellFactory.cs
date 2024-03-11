using Cards.States;

namespace Cards.Factories;

public class SpellFactory : ACardFactory<Spell, ICardState>
{
    public override Spell CreateCard(Color color)
    {
        return new() { Color = color };
    }

    public Spell CreateCard(Color color, int cost)
    {
        return new() { Color = color, Cost = cost };
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

    public Spell CreateInstantCard(Color color, int cost)
    {
        return new() { Color = color, Cost = cost, };
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
