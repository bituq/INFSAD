using Cards.States;

namespace Cards;

public abstract class APermanent : ACard<IPermanentState>
{
    public bool IsTapped { get; private set; }
    public required Player Owner { get; set; }

    public virtual void Tap() => IsTapped = true;

    public virtual void Untap() => IsTapped = false;
}
