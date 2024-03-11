namespace Cards.States;

public class PlayedState : ICardState
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
}
