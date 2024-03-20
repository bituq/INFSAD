using Colors;

namespace Cards.Factories;

public class CreatureFactory : APermanentFactory
{
    public override Creature CreateCard(AColor color)
    {
        return new() { Color = color, Cost = 0 };
    }

    public Creature CreateCard(AColor color, int cost)
    {
        return new() { Color = color, Cost = cost };
    }

    public Creature CreateCard(AColor color, int cost, int attack, int defence)
    {
        return new()
        {
            Color = color,
            Attack = attack,
            Defence = defence,
            Cost = cost
        };
    }
    
    public Creature CreateCard(AColor color, int cost, int attack, int defence, Effect effect)
    {
        return new()
        {
            Color = color,
            Attack = attack,
            Defence = defence,
            Cost = cost,
            Effect = effect
        };
    }

    public Creature CreateInstantCard(AColor color, int cost, int attack, int defence, Effect effect)
    {
        return new()
        {
            Color = color,
            Attack = attack,
            Defence = defence,
            Cost = cost,
            Effect = effect,
            IsInstantaneous = true
        };
    }
    public Creature CreateContinuousCard(AColor color, int cost, int attack, int defence, Effect effect)
    {
        return new()
        {
            Color = color,
            Attack = attack,
            Defence = defence,
            Cost = cost,
            Effect = effect,
            IsContinuous = true
        };
    }
}
