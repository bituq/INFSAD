using Cards.States;

namespace Cards;

public abstract class ACard<T>
    where T : ICardState
{
    public required Color Color { get; set; }
    public abstract T State { get; set; }
}
