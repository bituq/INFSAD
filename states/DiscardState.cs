namespace Cards.States;

public class DiscardState : ICardState
{
    public required ACard Card { get; set; }

    public void Discard() { }

    public void Draw()
    {
        Card.State = new DrawnState() { Card = Card };
    }

    public void Play()
    {
        Card.State = new PlayedState() { Card = Card };
    }

    public void SetIdle()
    {
        Card.State = new IdleState() { Card = Card };
    }
}
