using Cards.States;

namespace Cards;

public class Land : APermanent
{
    public override ICardState State { get; set; }

    public override bool Tap()
    {
        if (!base.Tap())
            return false;

        return true;
    }
}
