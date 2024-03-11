namespace Cards;

public class Creature : APermanent
{
    private int attack;
    private int defence;

    public int Attack
    {
        get => attack;
        set
        {
            attack = value;

            if (attack < 0)
                Discard();
        }
    }

    public int Defence
    {
        get => defence;
        set
        {
            defence = value;

            if (defence < 0)
                Discard();
        }
    }
}
