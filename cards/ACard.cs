using Cards.States;

namespace Cards;

public abstract class ACard
{
    public required Color Color { get; set; }
    public abstract ICardState State { get; set; }
}
