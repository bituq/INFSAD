namespace Cards.States;

public class IdleState : ICardState
{
    public required ACard<ICardState> Card { get; set; }

    public void Discard()
    {
        Card.State = new DiscardState() { Card = Card };
    }

    public void Draw()
    {
        Card.State = new DrawnState() { Card = Card };
    }

    public void Play()
    {
        Card.State = new PlayedState() { Card = Card };
    }

    public void SetIdle() { }
}
