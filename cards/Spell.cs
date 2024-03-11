using Cards.States;

namespace Cards;

public class Spell : ACard<ICardState>
{
    private List<Effect> effects = new();
    public int Cost { get; set; }
    public bool IsInstantaneous { get; set; }

    public Spell()
    {
        State = new IdleState() { Card = this };
    }

    public List<Effect> Effects
    {
        get => effects;
        set => effects = value;
    }
    public override ICardState State { get; set; }
}
