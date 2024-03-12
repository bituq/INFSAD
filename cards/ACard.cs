using Cards.States;

namespace Cards;

public abstract class ACard
{
    private ICardState state;

    public required Color Color { get; set; }
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
