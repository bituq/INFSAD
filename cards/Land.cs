using Cards.States;

namespace Cards;

public class Land : APermanent
{
    public bool Used { get; set; } = false;

    public override bool Tap()
    {
        if (!base.Tap())
            return false;

        return true;
    }
}
