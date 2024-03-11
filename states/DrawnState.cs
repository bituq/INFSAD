namespace Cards.States;

public class DrawnState : ICardState

{
    public required ACard<ICardState> Card { get; set; }

    public void Discard()
    {
        Card.State = new DiscardState() { Card = Card };
    }

    public void Draw() { }

    public void Play()
    {
        Card.State = new PlayedState() { Card = Card };
    }

    public void SetIdle()
    {
        Card.State = new IdleState() { Card = Card };
    }
}
