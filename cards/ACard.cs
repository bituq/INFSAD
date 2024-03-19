using Cards.States;
using Colors;

namespace Cards;

public abstract class ACard
{
    private ICardState state;

    public required AColor Color { get; set; }
    public required int Cost { get; set; }
    public ICardState State
    {
        get => state;
        set
        {
            state = value;
            OnStateChanged?.Invoke(value);
        }
    }
    public delegate void ChangeState(ICardState state);
    public event ChangeState OnStateChanged;

    public ACard()
    {
        State = new IdleState() { Card = this };
    }
}
