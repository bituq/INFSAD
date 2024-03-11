namespace Cards.Factories;

public class CreatureFactory : APermanentFactory
{
    public override Creature CreateCard(Color color)
    {
        return new() { Color = color };
    }

    public Creature CreateCard(Color color, int attack, int defence)
    {
        return new()
        {
            Color = color,
            Attack = attack,
            Defence = defence
        };
    }
}
