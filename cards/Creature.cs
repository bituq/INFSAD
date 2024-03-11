using Cards.States;

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
                State.Discard();
        }
    }

    public int Defence
    {
        get => defence;
        set
        {
            defence = value;

            if (defence < 0)
                State.Discard();
        }
    }

    public override ICardState State { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
