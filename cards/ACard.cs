using Cards.States;

namespace Cards;

public abstract class ACard
{
    public required Color Color { get; set; }
    public ICardState State { get; set; }

    public ACard()
    {
        State = new IdleState() { Card = this };
    }
}
