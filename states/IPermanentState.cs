namespace Cards.States;

public interface IPermanentState : ICardState
{
    public void Tap();
    public void Untap();
}
