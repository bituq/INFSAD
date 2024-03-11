namespace Cards.States;

public class TapState : IPermanentState
{
    public required APermanent Card { get; set; }

    public void Discard()
    {
        Card.State = (IPermanentState)new DiscardState() { Card = Card };
    }

    public void Draw()
    {
        Card.State = (IPermanentState)new DrawnState() { Card = Card };
    }

    public void Play() { }

    public void SetIdle()
    {
        Card.State = (IPermanentState)new IdleState() { Card = Card };
    }

    public void Tap() { }

    public void Untap()
    {
        Card.State = (IPermanentState)new PlayedState() { Card = Card };
    }
}
