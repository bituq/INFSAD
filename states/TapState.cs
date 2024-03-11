namespace Cards.States;

public class TapState : ICardState
{
    public required ACard Card { get; set; }

    public void Discard()
    {
        Card.State = new DiscardState() { Card = Card };
    }

    public void Draw()
    {
        Card.State = new DrawnState() { Card = Card };
    }

    public void Play() { }

    public void SetIdle()
    {
        Card.State = new IdleState() { Card = Card };
    }

    public void Tap() { }

    public void Untap()
    {
        Card.State = new PlayedState() { Card = Card };
    }
}
