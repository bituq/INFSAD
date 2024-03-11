using Cards.States;

namespace Cards;

public abstract class APermanent : ACard
{
    public bool IsTapped { get; private set; }

    public virtual bool Tap()
    {
        if (State is not PlayedState)
            return false;

        IsTapped = true;
        return true;
    }

    public virtual bool Untap()
    {
        if (State is not PlayedState)
            return false;

        IsTapped = false;
        return true;
    }
}
