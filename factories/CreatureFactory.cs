namespace Cards.Factories;

public class CreatureFactory : APermanentFactory
{
    public override Creature CreateCard(Color color)
    {
        return new() { Color = color, Cost = 0 };
    }

    public Creature CreateCard(Color color, int cost)
    {
        return new() { Color = color, Cost = cost };
    }

    public Creature CreateCard(Color color, int cost, int attack, int defence)
    {
        return new()
        {
            Color = color,
            Attack = attack,
            Defence = defence,
            Cost = cost
        };
    }
}
